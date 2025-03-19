using Microsoft.EntityFrameworkCore;

namespace BlackArm.Application.Paging;

public class PagedList<T>
{
    public List<T> Items { get; set; }
    public MetaData MetaData { get; set; }

    public PagedList(List<T> items, int count, int pageNumber, int pageSize)
    {
        Items = items;
        MetaData = new MetaData
        {
            TotalCount = count,
            PageSize = pageSize,
            CurrentPage = pageNumber,
            TotalPages = (int)Math.Ceiling(count / (double)pageSize)
        };
    }

    // Пустой конструктор для сериализации
    public PagedList()
    {
        Items = new List<T>();
        MetaData = new MetaData();
    }

    public static PagedList<T> ToPagedList(IEnumerable<T> source, int pageNumber, int pageSize)
    {
        var count = source.Count();
        var items = source.ToList();
        return new PagedList<T>(items, count, pageNumber, pageSize);
    }
}