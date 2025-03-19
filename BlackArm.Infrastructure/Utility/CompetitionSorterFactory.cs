using BlackArm.Application.Contracts;
using BlackArm.Application.Sort;

namespace BlackArm.Infrastructure.Utility;

public static class CompetitionSorterFactory
{
    public static ICompetitionSorter Create(string? orderBy)
    {
        if (string.IsNullOrWhiteSpace(orderBy))
            return new DefaultSorter();

        return orderBy.ToLower() switch
        {
            "date" => new DateAscendingSorter(),
            "date desc" => new DateDescendingSorter(),
            "name" => new NameSorter(false),
            "name desc" => new NameSorter(true),
            _ => new DefaultSorter()
        };
    }
}