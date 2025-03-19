using BlackArm.Application.Contracts;
using BlackArm.Domain.Models;

namespace BlackArm.Application.Sort;

public class DefaultSorter : ICompetitionSorter
{
    public IQueryable<Competition> ApplySort(IQueryable<Competition> query) 
        => query.OrderBy(x => x.CompetitionName);

    public List<Competition> ApplyMemorySort(List<Competition> competitions) 
        => competitions;
}