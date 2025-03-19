using AutoMapper;
using BlackArm.API.ActionFilters;
using BlackArm.API.DTOs;
using BlackArm.Application.Contracts;
using BlackArm.Application.PhotoService.ArmWrestler.Profile;
using BlackArm.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Newtonsoft.Json;

namespace BlackArm.API.Controllers;

[Route("api/[controller]")]
[ApiController]
//[ResponseCache(CacheProfileName = "120SecondsDuration")]
public class ArmWrestlerController : ControllerBase
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly ILoggerManager _logger;
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IPhotoService _photoService;

    public ArmWrestlerController(IRepositoryManager repository,
        IMapper mapper, 
        ILoggerManager logger,
        IWebHostEnvironment webHostEnvironment,
        IPhotoService photoService)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
        _webHostEnvironment = webHostEnvironment;
        _photoService = photoService;
    }

    [HttpGet]
    public async Task<IActionResult> GetArmWrestlers()
    {
        var armWrestlers = await _repository.ArmWrestler.GetWrestlersAsync(new CancellationToken(), trackChanges:false);
        var armWrestlersDto = _mapper.Map<IEnumerable<ArmWrestlerDto>>(armWrestlers);
        
        return Ok(armWrestlersDto);
    }

    [HttpGet("{id}", Name = "ArmWrestlerById")]
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
        _logger.LogInfo($"Received PUT request for ID: {id}, Data: {JsonConvert.SerializeObject(armWrestler)}" );

        var armWrestlerEntity = await _repository.ArmWrestler.GetWrestlerAsync(id, trackChanges: true);
        if (armWrestlerEntity == null)
        {
            _logger.LogWarning($"ArmWrestler with ID {id} not found.");
            return NotFound();
        }

        _mapper.Map(armWrestler, armWrestlerEntity);
        _logger.LogInfo($"Mapped entity: {JsonConvert.SerializeObject(armWrestlerEntity)}");

        _repository.ArmWrestler.UpdateWrestler(armWrestlerEntity); // Явно вызываем обновление
        await _repository.SaveAsync();

        _logger.LogInfo("ArmWrestler updated successfully.");
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
    
    [HttpPost("{userId}/photo")]
    public async Task<IActionResult> UploadPhoto(Guid userId, IFormFile photo)
    {
        try
        {
            var photoPath = await _photoService.UploadPhotoAsync(userId, photo, _webHostEnvironment.ContentRootPath);
            return Ok(new { PhotoPath = photoPath });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(ex.Message);
        }
    }
   
    [HttpGet("{userId}/photo")]
    public async Task<IActionResult> GetPhotoMetadata(Guid userId)
    {
        try
        {
            var photoPath = await _photoService.GetPhotoPathAsync(userId);
            return Ok(new { PhotoPath = photoPath });
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(ex.Message);
        }
    }
   
    [HttpGet("{userId}/photo/file")]
    public async Task<IActionResult> GetPhotoFile(Guid userId)
    {
        try
        {
            var (fileResult, fileName) = await _photoService.GetPhotoFileAsync(userId, _webHostEnvironment.ContentRootPath);
            return File(fileResult.FileStream, fileResult.ContentType, fileName);
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(ex.Message);
        }
        catch (FileNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
    
}