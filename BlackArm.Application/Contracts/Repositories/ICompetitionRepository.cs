using BlackArm.Domain.Models;

namespace BlackArm.Application.Contracts;

public interface ICompetitionRepository
{
    Task<IEnumerable<Competition>> GetCompetitionsAsync( CancellationToken cancelationToken,bool trackChanges);
    
    Task<Competition> GetCompetitionAsync(Guid competitionId, bool trackChanges);
    
    void CreateCompetition(Competition competition);
    
    void RemoveCompetition(Competition competition);
}