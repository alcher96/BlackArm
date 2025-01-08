using BlackArm.Application.Contracts;
using BlackArm.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BlackArm.Infrastructure;

public class ArmWrestlerRepository: RepositoryBase<ArmWrestler>, IArmWrestlerRepository
{
    public ArmWrestlerRepository(ArmWrestlersDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<ArmWrestler>> GetWrestlersAsync(CancellationToken cancelationToken, bool trackChanges) =>
        await FindAll(trackChanges).OrderBy(o => o.FirstName).ToListAsync(cancelationToken);

    public  async Task<ArmWrestler> GetWrestlerAsync(Guid wrestlerId, bool trackChanges)=>
         FindByCondition(a => a.ArmWrestlerId.Equals(wrestlerId), trackChanges).SingleOrDefault();


    public void CreateArmWrestler(ArmWrestler wrestler) => Create(wrestler);
    public void DeleteWrestler(ArmWrestler wrestler) => Delete(wrestler);


    public void UpdateWrestler(ArmWrestler wrestler)
    {
        throw new NotImplementedException();
    }

   
}