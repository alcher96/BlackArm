using BlackArm.Application.Contracts;
using BlackArm.Domain;

namespace BlackArm.Infrastructure;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly ArmWrestlersDbContext _context;
    private readonly Lazy<IArmWrestlerRepository> _armWrestlerRepository;
    
    public RepositoryManager( ArmWrestlersDbContext context )
    {
        _context = context;
        _armWrestlerRepository = new Lazy<IArmWrestlerRepository>(() => new ArmWrestlerRepository(context));
    }
    
    public IArmWrestlerRepository ArmWrestler => _armWrestlerRepository.Value;
    public Task SaveAsync() => _context.SaveChangesAsync();
}