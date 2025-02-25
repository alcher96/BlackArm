using BlackArm.Application.Contracts;
using BlackArm.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BlackArm.Infrastructure;

public class RoundRepository : RepositoryBase<Round>, IRoundRepository
{
    public RoundRepository(ArmWrestlersDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Round>> GetAllRoundsAsync( Guid fightId, CancellationToken cancellationToken, bool trackChanges)
    {
        var rounds = await FindByCondition(f => f.FightId == fightId, trackChanges)
            .Include(r => r.Winner)
            .Include(r => r.StyleUsed)
            .OrderBy(r => r.RoundNumber).ToListAsync();
        return rounds;
    }

    public async Task<Round> GetRoundAsync(Guid roundId,
        CancellationToken cancellationToken,
        bool trackChanges) =>
        await FindByCondition(r => r.RoundId.Equals(roundId), trackChanges)
            .Include(r => r.Winner)
            .Include(r => r.StyleUsed)
            .SingleOrDefaultAsync();
    

    public void CreateRoundForFight(Guid fightId, Round round, CancellationToken cancellationToken,
        bool trackChanges)
    {
        round.FightId = fightId;
        Create(round);
    }

    public void DeleteRound(Round round)
    {
        Delete(round);
    }
}