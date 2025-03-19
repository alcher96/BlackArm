using BlackArm.Domain.Models;

namespace BlackArm.Application.Contracts;

public interface ICompetitionSorter
{
    IQueryable<Competition> ApplySort(IQueryable<Competition> query);
    List<Competition> ApplyMemorySort(List<Competition> competitions);
}