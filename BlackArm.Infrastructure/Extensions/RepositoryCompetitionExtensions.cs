using BlackArm.Application.Paging;
using BlackArm.Domain.Models;
using Microsoft.Extensions.DependencyInjection;

namespace BlackArm.Infrastructure.Extensions;

public static class RepositoryCompetitionExtensions
{
    public static IQueryable<Competition> Search(this IQueryable<Competition> competitions, string? searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
        {
            return competitions;
        }

        var lowercaseSearchTerm = searchTerm.Trim().ToLower();
        return competitions.Where(c=> c.CompetitionName.ToLower().Contains(lowercaseSearchTerm));
    }
    
    public static string GenerateCacheKeyForCompetitions(CompetitionParameters parameters)
    {
        return $"Competitions:{parameters.SearchTerm}:{parameters.OrderBy}:{parameters.PageNumber}:{parameters.PageSize}";
    }
    
    
}