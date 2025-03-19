using BlackArm.API.Extensions;
using BlackArm.Application.Cache;
using BlackArm.Application.Contracts;
using BlackArm.Application.Paging;
using BlackArm.Domain.Models;
using BlackArm.Infrastructure.Extensions;
using BlackArm.Infrastructure.Utility;
using Microsoft.EntityFrameworkCore;

namespace BlackArm.Infrastructure;

public class CompetitionRepository : RepositoryBase<Competition>, ICompetitionRepository
{
    private readonly ICacheService _cacheService;
    private const string CompetitionsCacheKeyPrefix = "competitions_";

    public CompetitionRepository(ArmWrestlersDbContext context, ICacheService cacheService) : base(context)
    {
        _cacheService = cacheService ?? throw new ArgumentNullException(nameof(cacheService));;
    }

    public async Task<PagedList<Competition>> GetCompetitionsAsync(CompetitionParameters competitionParameters, CancellationToken cancellationToken, bool trackChanges)
    {
        // Формируем уникальный ключ для кэша на основе параметров запроса
        var cacheKey = $"{CompetitionsCacheKeyPrefix}list_page{competitionParameters.PageNumber}_size{competitionParameters.PageSize}_search{competitionParameters.SearchTerm}_order{competitionParameters.OrderBy}";
        
        var cachedCompetitions = await _cacheService.GetAsync<PagedList<Competition>>(cacheKey);
        if (cachedCompetitions != null)
        {
            Console.WriteLine($"Returning cached data: TotalCount={cachedCompetitions.MetaData.TotalCount}, PageNumber={cachedCompetitions.MetaData.CurrentPage}, PageSize={cachedCompetitions.MetaData.PageSize}");
            return cachedCompetitions;
        }
        
        var query = FindAll(trackChanges)
            .Search(competitionParameters.SearchTerm);

        // Выбираем сортировщик
        var sorter = CompetitionSorterFactory.Create(competitionParameters.OrderBy);

        // Применяем сортировку на уровне базы
        query = sorter.ApplySort(query);

        // Подсчитываем общее количество
        var totalCount = await query.CountAsync(cancellationToken);

        // Применяем пагинацию и загружаем данные
        List<Competition> competitions;
        if (competitionParameters.PageSize.HasValue && competitionParameters.PageSize > 0)
        {
            competitions = await query
                .Skip((competitionParameters.PageNumber - 1) * competitionParameters.PageSize.Value)
                .Take(competitionParameters.PageSize.Value)
                .ToListAsync(cancellationToken);
        }
        else
        {
            competitions = await query.ToListAsync(cancellationToken);
        }

        // Применяем сортировку в памяти, если требуется
        competitions = sorter.ApplyMemorySort(competitions);

        var result = new PagedList<Competition>(
            competitions,
            totalCount,
            competitionParameters.PageSize.HasValue ? competitionParameters.PageNumber : 1,
            competitionParameters.PageSize.HasValue ? competitionParameters.PageSize.Value : totalCount);

        await _cacheService.SetAsync(cacheKey, result, TimeSpan.FromMinutes(5));
        return result;
    }
 


    public async Task<Competition> GetCompetitionAsync(Guid competitionId, bool trackChanges) =>
    await FindByCondition(x => x.CompetitionId == competitionId, trackChanges).SingleOrDefaultAsync();


    public void CreateCompetition(Competition competition) => Create(competition);
  

    public void RemoveCompetition(Competition competition) => Delete(competition);
    
    
}