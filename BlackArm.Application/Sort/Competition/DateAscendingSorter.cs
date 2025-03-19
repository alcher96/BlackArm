using BlackArm.Application.Contracts;
using BlackArm.Domain.Models;

namespace BlackArm.Application.Sort;

public class DateAscendingSorter : ICompetitionSorter
{
    public IQueryable<Competition> ApplySort(IQueryable<Competition> query) 
        => query.OrderBy(x => x.CompetitionDate);

    public List<Competition> ApplyMemorySort(List<Competition> competitions) 
        => competitions; // Не требуется, так как сортировка уже на уровне базы
}