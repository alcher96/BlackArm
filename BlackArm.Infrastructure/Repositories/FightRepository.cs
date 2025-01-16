using BlackArm.Application.Contracts;
using BlackArm.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BlackArm.Infrastructure;

public class FightRepository : RepositoryBase<Fight>, IFightRepository
{
    public FightRepository(ArmWrestlersDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Fight>> GetFightsAsync(Guid CompetitionId, Fight FightId, CancellationToken cancellationToken, bool trackChanges)
    {
        var fights = await FindByCondition(f => f.CompetitionId == CompetitionId, trackChanges)
            .OrderBy(f => f.Rounds).ToListAsync();
        return fights;
    }

    public async Task<Fight> GetFightAsync(Guid CompetitionId, Guid FightId, CancellationToken cancellationToken,
        bool trackChanges) =>
        await FindByCondition(f => f.CompetitionId.Equals(CompetitionId) && f.FightId.Equals(FightId),
                 trackChanges)
            .SingleOrDefaultAsync();

    public void CreateFightForCompetition(Guid CompetitionId, Fight fight)
    {
        fight.CompetitionId = CompetitionId;
        Create(fight);
    }

    public void DeleteFight(Fight fight)
    {
        Delete(fight);
    }
}