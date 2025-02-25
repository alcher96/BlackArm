using BlackArm.Application.Contracts;
using BlackArm.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BlackArm.Infrastructure;

public class WrestlingStyleRepository :RepositoryBase<WrestlingStyle>, IStyleRepository
{
    public WrestlingStyleRepository(ArmWrestlersDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<WrestlingStyle>> GetWrestlingStylesAsync(CancellationToken cancellationToken,
        bool trackChanges) =>
        await FindAll(trackChanges).ToListAsync(cancellationToken);
   

    public async Task<WrestlingStyle> GetWrestlingStyleAsync(Guid styleId, CancellationToken cancellationToken, bool trackChanges) =>
        await FindByCondition(x => x.StyleId == styleId, trackChanges).SingleOrDefaultAsync();
   

    public void AddWrestlingStyle(WrestlingStyle style) => Create(style);
 
    public void RemoveWrestlingStyle(WrestlingStyle style) => Delete(style);

}