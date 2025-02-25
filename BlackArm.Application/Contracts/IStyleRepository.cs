using BlackArm.Domain.Models;

namespace BlackArm.Application.Contracts;

public interface IStyleRepository
{
    Task<IEnumerable<WrestlingStyle>> GetWrestlingStylesAsync(CancellationToken cancellationToken, bool trackChanges);
    
    Task<WrestlingStyle> GetWrestlingStyleAsync(Guid styleId, CancellationToken cancellationToken, bool trackChanges);
    
    void AddWrestlingStyle(WrestlingStyle style);
    
    void RemoveWrestlingStyle(WrestlingStyle style);
}