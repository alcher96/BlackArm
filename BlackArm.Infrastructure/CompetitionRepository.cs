using BlackArm.Application.Contracts;
using BlackArm.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BlackArm.Infrastructure;

public class CompetitionRepository : RepositoryBase<Competition>, ICompetitionRepository
{
    public CompetitionRepository(ArmWrestlersDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Competition>> GetCompetitionsAsync(CancellationToken cancelationToken, bool trackChanges) =>
    await FindAll(trackChanges).OrderBy(x => x.CompetitionName).ToListAsync(cancelationToken);


    public async Task<Competition> GetCompetitionAsync(Guid competitionId, bool trackChanges) =>
    await FindByCondition(x => x.CompetitionId == competitionId, trackChanges).SingleOrDefaultAsync();


    public void CreateCompetition(Competition competition) => Create(competition);
  

    public void RemoveCompetition(Competition competition) => Delete(competition);

}