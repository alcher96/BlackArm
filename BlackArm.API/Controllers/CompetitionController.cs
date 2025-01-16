using AutoMapper;
using BlackArm.API.DTOs.CompetitionsDto;
using BlackArm.Application.Contracts;
using BlackArm.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlackArm.API.Controllers;


[Route("api/competitions")]
[ApiController]
public class CompetitionController : ControllerBase
{
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _repository;

    public CompetitionController(ILoggerManager logger, IMapper mapper, IRepositoryManager repository)
    {
        _logger = logger;
        _mapper = mapper;
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetCompetitions()
    {
        var competition =await _repository.Competition.GetCompetitionsAsync(cancelationToken:default, trackChanges:false);
        var competitionDto = _mapper.Map<IEnumerable<CompetitionDto>>(competition);
        return Ok(competitionDto);
    }

    [HttpGet("{id}", Name = "CompetitionById")]
    public async Task<IActionResult> GetCompetitionById(Guid id)
    {
        var competition = await _repository.Competition.GetCompetitionAsync(id, trackChanges:false);
        var competitionDto = _mapper.Map<CompetitionDto>(competition);
        return Ok(competitionDto);
    }
    
    
    
    [HttpPost]
    public async Task<IActionResult> CreateCompetition([FromBody] CompetitionForCreationDto dto)
    {
        var competitionEntity = _mapper.Map<Competition>(dto);
        _repository.Competition.CreateCompetition(competitionEntity);
        await _repository.SaveAsync();
        
        var compToReturn = _mapper.Map<CompetitionDto>(competitionEntity);

        return CreatedAtRoute("CompetitionById", new { Id = compToReturn.CompetitionId }, compToReturn);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCompetition(Guid id, [FromBody] ComtetitionForUpdateDto updateDto)
    {
        var competitionEntity = await _repository.Competition.GetCompetitionAsync(id, trackChanges:true);
        _mapper.Map(updateDto, competitionEntity);
        await _repository.SaveAsync();
        return NoContent();
        
    }
}