using BlackArm.Application.Cache;
using BlackArm.Application.Contracts;
using BlackArm.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BlackArm.Infrastructure;

public class ArmWrestlerRepository: RepositoryBase<ArmWrestler>, IArmWrestlerRepository
{
    private readonly ICacheService _cacheService;

    public ArmWrestlerRepository(ArmWrestlersDbContext context, ICacheService cacheService) : base(context)
    {
        _cacheService = cacheService;
    }

    public async Task<IEnumerable<ArmWrestler>> GetWrestlersAsync(CancellationToken cancelationToken, bool trackChanges)
    {
        var cacheKey = "ArmWrestlers:All";
        var wrestlers = await _cacheService.GetAsync<List<ArmWrestler>>(cacheKey);
              await FindAll(trackChanges).OrderBy(o => o.FirstName).ToListAsync(cancelationToken);
        if (wrestlers == null)
        { 
            wrestlers = await FindAll(trackChanges).OrderBy(o => o.FirstName).ToListAsync(cancelationToken);
            await _cacheService.SetAsync(cacheKey, wrestlers, TimeSpan.FromMinutes(10)); // Кэшируем на 10 минут
        }

        return wrestlers;
    }


    public async Task<ArmWrestler> GetWrestlerAsync(Guid wrestlerId, bool trackChanges)
    {
        var cacheKey = $"ArmWrestlers:{wrestlerId}";
        var wrestler = await _cacheService.GetAsync<ArmWrestler>(cacheKey);

        if (wrestler == null)
        {
            wrestler = await FindByCondition(a => a.ArmWrestlerId.Equals(wrestlerId), trackChanges:true).SingleOrDefaultAsync();
            if (wrestler != null)
                await _cacheService.SetAsync(cacheKey, wrestler, TimeSpan.FromMinutes(10)); // Кэшируем на 10 минут
        }

        return wrestler;
    }



    public void CreateArmWrestler(ArmWrestler wrestler)
    {
        Create(wrestler);
        _cacheService.RemoveAsync("ArmWrestlers:All"); 
    }

    public void DeleteWrestler(ArmWrestler wrestler)
    {
        Delete(wrestler);
        _cacheService.RemoveAsync("ArmWrestlers:All");
    }


    public void UpdateWrestler(ArmWrestler wrestler)
    {
        Update(wrestler);
        var tasks = new[]
        {
            _cacheService.RemoveAsync($"ArmWrestlers:{wrestler.ArmWrestlerId}"),
            _cacheService.RemoveAsync("ArmWrestlers:All")
        };
        Task.WhenAll(tasks).GetAwaiter().GetResult();
        Console.WriteLine("Cache cleared for ArmWrestlers");
    }

   
}