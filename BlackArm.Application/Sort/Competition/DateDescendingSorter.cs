using BlackArm.Application.Contracts;
using BlackArm.Domain.Models;

namespace BlackArm.Application.Sort;

public class DateDescendingSorter : ICompetitionSorter
{
    public IQueryable<Competition> ApplySort(IQueryable<Competition> query) 
        => query.OrderByDescending(x => x.CompetitionDate);

    public List<Competition> ApplyMemorySort(List<Competition> competitions) 
        => competitions;
}