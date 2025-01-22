using AutoMapper;
using BlackArm.API.ActionFilters;
using BlackArm.API.DTOs.RoundsDto;
using BlackArm.Application.Contracts;
using BlackArm.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlackArm.API.Controllers;


[Route("api/rounds")]
[ApiController]
public class RoundController: ControllerBase
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly ILoggerManager _logger;

    public RoundController(IRepositoryManager repository, IMapper mapper, ILoggerManager logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    [HttpGet("{roundId}", Name = "GetRoundForFight")]
    public async Task<IActionResult> GetRoundForFight(Guid competitionId, 
        Guid fightId, 
        Guid roundId, 
        CancellationToken cancellationToken = default)
    {
       var roundDb = await _repository.Round
           .GetRoundAsync( fightId,roundId, cancellationToken,trackChanges:false);

       
       var round = _mapper.Map<RoundDto>(roundDb);
       return Ok(round);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllRoundsForFight(Guid fightId)
    {
        //var fight = _repository.Fight.GetFightAsync(competitionId, fightId, CancellationToken.None,trackChanges:false);
        
        
        var roundsFromDb = await _repository.Round.GetAllRoundsAsync(fightId, CancellationToken.None, trackChanges:false);
        
        var roundsDto = _mapper.Map<IEnumerable<RoundDto>>(roundsFromDb);
        return Ok(roundsDto);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateRoundForFight(Guid fightId, [FromBody] RoundForCreationDto round)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogError("Invalid model state");
            return UnprocessableEntity(ModelState);
        }

        //var fight = _repository.Fight.GetFightAsync(CompetitionId, FightId, cancellationToken: default,
         //   trackChanges: false);
        var roundEntity = _mapper.Map<Round>(round);
        _repository.Round.CreateRoundForFight(fightId, roundEntity,CancellationToken.None,trackChanges: false);
        await _repository.SaveAsync();
        var roundToReturn = _mapper.Map<RoundDto>(roundEntity);
        
        //return CreatedAtRoute("GetRoundForFight", new {competitionId,fightId, id = roundToReturn.RoundId}, roundToReturn);
        return Ok(roundToReturn);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteRoundForFight(Guid fightId,Guid roundId,
        CancellationToken cancellationToken = default)
    {
        //var fight = _repository.Fight.GetFightAsync(competitionId,fightId, cancellationToken, trackChanges: false);
        var roundForFight = await _repository.Round.GetRoundAsync(fightId,roundId, cancellationToken, trackChanges: false);
        if (roundForFight == null)
        {
            _logger.LogError("Round not found");
            return NotFound();
        }
        
        _repository.Round.DeleteRound(roundForFight);
        await _repository.SaveAsync();
        return NoContent();
    }
}