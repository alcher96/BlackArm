using BlackArm.Application.Cache;
using BlackArm.Application.Contracts;
using BlackArm.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BlackArm.Infrastructure;

public class FightRepository : RepositoryBase<Fight>, IFightRepository
{
    private readonly ICacheService _cacheService;

    public FightRepository(ArmWrestlersDbContext context, ICacheService cacheService) : base(context)
    {
        _cacheService = cacheService;
    }

    public async Task<IEnumerable<Fight>> GetFightsAsync(Guid CompetitionId, CancellationToken cancellationToken, bool trackChanges)
    {
        
        var fights = await FindByCondition(f => f.CompetitionId == CompetitionId, trackChanges)
            .Include(f => f.Wrestler1)
            .Include(f =>f.Wrestler2)
            .ToListAsync();
        return fights;
    }

    public async Task<Fight> GetFightAsync(Guid FightId, CancellationToken cancellationToken,
        bool trackChanges) =>
        await FindByCondition(f =>  f.FightId.Equals(FightId),
                 trackChanges)
            .Include(f => f.Wrestler1)
            .Include(f =>f.Wrestler2)
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