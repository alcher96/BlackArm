using AutoMapper;
using BlackArm.API.ActionFilters;
using BlackArm.API.DTOs;
using BlackArm.Application.Contracts;
using BlackArm.Domain.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace BlackArm.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ArmWrestlerController : ControllerBase
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly ILoggerManager _logger;

    public ArmWrestlerController(IRepositoryManager repository, IMapper mapper, ILoggerManager logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetArmWrestlers()
    {
        var armWrestlers = await _repository.ArmWrestler.GetWrestlersAsync(new CancellationToken(), trackChanges:false);
        var armWrestlersDto = _mapper.Map<IEnumerable<ArmWrestlerDto>>(armWrestlers);
        
        return Ok(armWrestlersDto);
    }

    [HttpGet("{id}", Name = "ArmWrestlerById")]
    [ServiceFilter(typeof(ValidateArmwrestlerExistsAttribute))]
    public async Task<IActionResult> GetArmWrestlerById(Guid id)
    {
        var armWrestler = await _repository.ArmWrestler.GetWrestlerAsync(id, trackChanges:false);
        
        var armWrestlerDto = _mapper.Map<ArmWrestlerDto>(armWrestler);
        
        return Ok(armWrestlerDto);
    }


    [HttpPost]
    [ServiceFilter(typeof(ValidateArmwrestlerExistsAttribute))]
    public async Task<IActionResult> CreateArmWrestler([FromBody] ArmWrestlerForCreationDto armWrestler)
    {
        var armWrestlerEntity = _mapper.Map<ArmWrestler>(armWrestler);
        
        _repository.ArmWrestler.CreateArmWrestler(armWrestlerEntity);
        await _repository.SaveAsync();
        
        var armToReturn = _mapper.Map<ArmWrestlerDto>(armWrestlerEntity);
        
        return CreatedAtRoute("ArmWrestlerById", new {Id = armToReturn.ArmWrestlerId}, armToReturn);
    }

    [HttpPut("{id}")]
    [ServiceFilter(typeof(ValidateArmwrestlerExistsAttribute))]
    public async Task<IActionResult> UpdateArmWrestler(Guid id, [FromBody] ArmWrestlerForUpdateDto armWrestler)
    {
        var armWrestlerEntity = await _repository.ArmWrestler.GetWrestlerAsync(id, trackChanges:true);
        // var armWrestlerEntity = HttpContext.Items["armWrestler"] as ArmWrestler;
        _mapper.Map(armWrestler, armWrestlerEntity);
        await _repository.SaveAsync();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult PartialUpdateArmWrestler(Guid armId,
        [FromBody] JsonPatchDocument<ArmWrestlerForUpdateDto> patchDocument)
    {
        var armWrestler = _repository.ArmWrestler.GetWrestlerAsync(armId, trackChanges:true);
        var armToPatch = _mapper.Map<ArmWrestlerForUpdateDto>(armWrestler);
        patchDocument.ApplyTo(armToPatch);
        _mapper.Map(armToPatch, armWrestler);
        _repository.SaveAsync();
        return NoContent();
    }
}