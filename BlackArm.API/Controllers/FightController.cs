using AutoMapper;
using BlackArm.API.ActionFilters;
using BlackArm.API.DTOs.FightsDto;
using BlackArm.Application.Contracts;
using BlackArm.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlackArm.API.Controllers;

[Route("api/fights")]
[ApiController]
[ResponseCache(CacheProfileName = "120SecondsDuration")]
public class FightController : ControllerBase
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public FightController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    [HttpGet("{id}", Name = "GetFightForCompetition")]
    public async Task<IActionResult> GetFightForCompetition(Guid competitionId, Guid id,
        CancellationToken cancellationToken)
    {
        var competition = await _repository.Competition.GetCompetitionAsync(competitionId, trackChanges: false);
        
        var fight = await _repository.Fight.GetFightAsync(competitionId, id, cancellationToken, trackChanges: false);
        
        var fights = _mapper.Map<FightWithWrestlersNameDto>(fight);
        return Ok(fights);
    }

    [HttpGet]
    public async Task<IActionResult> GetFightsForCompetition(Guid competitionId, CancellationToken cancellationToken)
    {
        //var competition = await _repository.Competition.GetCompetitionAsync(competitionId, trackChanges: false);
        var fightsFromDb = await _repository.Fight.GetFightsAsync(competitionId, cancellationToken, trackChanges: false);
        var fightsDto = _mapper.Map<IEnumerable<FightWithWrestlersNameDto>>(fightsFromDb);
        return Ok(fightsDto);
    }

[HttpPost]
    public async Task<IActionResult> CreateFighForCompetition(Guid competitionId, [FromBody] FightForCreatingDto fight)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogError("Invalid model state");
            return UnprocessableEntity(ModelState);
        }

        
        var competition = await _repository.Competition.GetCompetitionAsync(competitionId, trackChanges: false);
        var fightEntity = _mapper.Map<Fight>(fight);
        _repository.Fight.CreateFightForCompetition(competitionId, fightEntity);
        await _repository.SaveAsync();
        var fightToReturn = _mapper.Map<FightDto>(fightEntity);


        //return CreatedAtRoute("GetFightForCompetition", new {competitionId, id = fightToReturn.FightId}, fightToReturn);
        return Ok(fightToReturn);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteFightForCompetition(Guid competitionId, Guid id,
        CancellationToken cancellationToken)
    {
        var fight =await _repository.Fight.GetFightAsync(competitionId, id, cancellationToken, trackChanges: false);
        if (fight == null)
        {
            _logger.LogError("Fight not found");
        }
         _repository.Fight.DeleteFight(fight);
        await _repository.SaveAsync();
        return NoContent();
        
    }
}