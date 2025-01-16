using BlackArm.Application.Contracts;
using BlackArm.Domain;

namespace BlackArm.Infrastructure;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly ArmWrestlersDbContext _context;
    private readonly Lazy<IArmWrestlerRepository> _armWrestlerRepository;
    private readonly Lazy<ICompetitionRepository> _competitionRepository;
    private readonly Lazy<IFightRepository> _fightRepository;
    
    public RepositoryManager( ArmWrestlersDbContext context )
    {
        _context = context;
        _armWrestlerRepository = new Lazy<IArmWrestlerRepository>(() => new ArmWrestlerRepository(context));
        _competitionRepository = new Lazy<ICompetitionRepository>(() => new CompetitionRepository(context));
        _fightRepository = new Lazy<IFightRepository>(() => new FightRepository(context));
    }
    
    public IArmWrestlerRepository ArmWrestler => _armWrestlerRepository.Value;
    public ICompetitionRepository Competition => _competitionRepository.Value;
    
    public IFightRepository Fight => _fightRepository.Value;
    public Task SaveAsync() => _context.SaveChangesAsync();
}