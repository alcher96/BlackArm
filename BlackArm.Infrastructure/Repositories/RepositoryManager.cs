using BlackArm.Application.Cache;
using BlackArm.Application.Contracts;
using BlackArm.Domain;


namespace BlackArm.Infrastructure;

public sealed class RepositoryManager : IRepositoryManager
{
   
    private readonly ArmWrestlersDbContext _context;
    private readonly ICacheService _cache;
    private readonly Lazy<IArmWrestlerRepository> _armWrestlerRepository;
    private readonly Lazy<ICompetitionRepository> _competitionRepository;

    private readonly Lazy<IFightRepository> _fightRepository;
    private readonly Lazy<IRoundRepository> _roundRepository;
    private readonly Lazy<IStyleRepository> _styleRepository;

    
    public RepositoryManager(ArmWrestlersDbContext context, ICacheService cacheService)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _cache = cacheService ?? throw new ArgumentNullException(nameof(cacheService));

        _armWrestlerRepository = new Lazy<IArmWrestlerRepository>(() => 
            new ArmWrestlerRepository(_context, _cache));
        _competitionRepository = new Lazy<ICompetitionRepository>(() => 
            new CompetitionRepository(_context, _cache));
        _fightRepository = new Lazy<IFightRepository>(() => 
            new FightRepository(_context, _cache));
        _roundRepository = new Lazy<IRoundRepository>(() => 
            new RoundRepository(_context));
        _styleRepository = new Lazy<IStyleRepository>(() => 
            new WrestlingStyleRepository(_context));
    }
    
    public IArmWrestlerRepository ArmWrestler => _armWrestlerRepository.Value;
    public ICompetitionRepository Competition => _competitionRepository.Value;

    
    public IFightRepository Fight => _fightRepository.Value;
    
    public IRoundRepository Round => _roundRepository.Value;
    
    public IStyleRepository Style => _styleRepository.Value;
    public Task SaveAsync() => _context.SaveChangesAsync();
}