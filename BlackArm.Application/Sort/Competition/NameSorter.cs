using BlackArm.API.Extensions;
using BlackArm.Application.Contracts;
using BlackArm.Domain.Models;

namespace BlackArm.Application.Sort;

public class NameSorter : ICompetitionSorter
{
    private readonly bool _descending;

    public NameSorter(bool descending = false) => _descending = descending;

    public IQueryable<Competition> ApplySort(IQueryable<Competition> query) 
        => query.OrderBy(x => x.CompetitionName); // Базовая сортировка для пагинации

    public List<Competition> ApplyMemorySort(List<Competition> competitions) 
        => _descending 
            ? competitions.OrderByDescending(x => ExtractNumberFromCompNameExtinsions.ExtractNumber(x.CompetitionName)).ToList()
            : competitions.OrderBy(x => ExtractNumberFromCompNameExtinsions.ExtractNumber(x.CompetitionName)).ToList();
}