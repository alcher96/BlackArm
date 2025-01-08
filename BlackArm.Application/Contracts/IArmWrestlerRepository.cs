using BlackArm.Domain.Models;

namespace BlackArm.Application.Contracts;

public interface IArmWrestlerRepository
{
    Task<IEnumerable<ArmWrestler>> GetWrestlersAsync(CancellationToken cancelationToken, bool trackChanges);
    
    Task<ArmWrestler> GetWrestlerAsync(Guid wrestlerId, bool trackChanges);
    
    void CreateArmWrestler(ArmWrestler wrestler);
    
    void UpdateWrestler(ArmWrestler wrestler);
    
    void DeleteWrestler(ArmWrestler wrestler);
}