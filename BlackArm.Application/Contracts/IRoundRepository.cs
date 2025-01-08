using BlackArm.Domain.Models;

namespace BlackArm.Application.Contracts;

public interface IRoundRepository
{
    Task<IEnumerable<Round>> GetAllRoundsAsync(Guid FightId, Guid RoundId, CancellationToken cancellationToken, bool trackChanges);
    
    Task<Round> GetRoundAsync(Guid FightId, Guid RoundId, CancellationToken cancellationToken, bool trackChanges);
    
    void CreateRoundForFight(Guid FightId,Round round, CancellationToken cancellationToken, bool trackChanges);
    
    void DeleteRound(Round round, CancellationToken cancellationToken, bool trackChanges);
}