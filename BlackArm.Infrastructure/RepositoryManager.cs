using BlackArm.Application.Contracts;
using BlackArm.Domain;

namespace BlackArm.Infrastructure;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly ArmWrestlersDbContext _context;
    private readonly Lazy<IArmWrestlerRepository> _armWrestlerRepository;
    private readonly Lazy<ICompetitionRepository> _competitionRepository;
    
    public RepositoryManager( ArmWrestlersDbContext context )
    {
        _context = context;
        _armWrestlerRepository = new Lazy<IArmWrestlerRepository>(() => new ArmWrestlerRepository(context));
        _competitionRepository = new Lazy<ICompetitionRepository>(() => new CompetitionRepository(context));
    }
    
    public IArmWrestlerRepository ArmWrestler => _armWrestlerRepository.Value;
    public ICompetitionRepository Competition => _competitionRepository.Value;
    public Task SaveAsync() => _context.SaveChangesAsync();
}