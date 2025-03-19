using AutoMapper;
using BlackArm.API.ActionFilters;
using BlackArm.API.DTOs.CompetitionsDto;
using BlackArm.Application.Contracts;
using BlackArm.Application.Paging;
using BlackArm.Domain.Models;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BlackArm.API.Controllers;


[Route("api/[controller]")]
[ApiController]
//[ResponseCache(CacheProfileName = "120SecondsDuration")]
//[HttpCacheExpiration(CacheLocation=CacheLocation.Public, MaxAge =60)]
//[HttpCacheValidation(MustRevalidate =false)]
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
    public async Task<IActionResult> GetCompetitions([FromQuery] CompetitionParameters parameters)
    {
        var competition =await _repository.Competition.GetCompetitionsAsync(parameters,cancelationToken:default, trackChanges:false);
        
            // Response.Headers.Append("X-Pagination",JsonConvert.SerializeObject(competition.MetaData)); //for paging
        
        var competitionDto = _mapper.Map<IEnumerable<CompetitionDto>>(competition);
        
        var metadata = new
        {
            competition.MetaData.CurrentPage,
            competition.MetaData.TotalPages,
            competition.MetaData.PageSize,
            competition.MetaData.TotalCount,
            competition.MetaData.HasPreviousPage,
            competition.MetaData.HasNextPage
        };
        Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
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

        //return CreatedAtRoute("CompetitionById", new { Id = compToReturn.CompetitionId }, compToReturn);
        return Ok(compToReturn);
    }

    [HttpPut("{id}")]
    
    public async Task<IActionResult> UpdateCompetition(Guid id, [FromBody] ComtetitionForUpdateDto updateDto)
    {
        var competitionEntity = await _repository.Competition.GetCompetitionAsync(id, trackChanges:true);
        _mapper.Map(updateDto, competitionEntity);
        await _repository.SaveAsync();
        return NoContent();
        
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCompetition(Guid id)
    {
        var competition = await _repository.Competition.GetCompetitionAsync(id, trackChanges:true);
        if (competition == null)
        {
            _logger.LogError($"Competition with id: {id} not found");
            
        }
        _repository.Competition.RemoveCompetition(competition);
        _repository.SaveAsync();
        return NoContent();
    }
}