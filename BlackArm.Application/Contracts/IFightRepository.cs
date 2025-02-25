using BlackArm.Domain.Models;

namespace BlackArm.Application.Contracts;

public interface IFightRepository
{
    Task<IEnumerable<Fight>> GetFightsAsync(Guid CompetitionId, CancellationToken cancellationToken, bool trackChanges);
    
    Task<Fight> GetFightAsync(Guid FightId, CancellationToken cancellationToken, bool trackChanges);
    
    void CreateFightForCompetition(Guid CompetitionId, Fight fight);
    
    void DeleteFight(Fight FightId);
}