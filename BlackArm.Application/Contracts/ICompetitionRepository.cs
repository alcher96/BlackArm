using BlackArm.Application.Paging;
using BlackArm.Domain.Models;

namespace BlackArm.Application.Contracts;

public interface ICompetitionRepository
{
    Task<PagedList<Competition>> GetCompetitionsAsync(CompetitionParameters competitionParameters, CancellationToken cancelationToken,bool trackChanges);
    
    Task<Competition> GetCompetitionAsync(Guid competitionId, bool trackChanges);
    
    void CreateCompetition(Competition competition);
    
    void RemoveCompetition(Competition competition);
}