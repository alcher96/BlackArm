namespace BlackArm.Application.Paging;

public abstract class RequestParameters
{
    const int maxPageSize = 50;
    public int PageNumber { get; set; } = 1;

    private int? _pageSize = null;
    
    public string? OrderBy { get; set; }

    public int? PageSize
    {
        get => _pageSize;
        set => _pageSize = (value.HasValue && value > maxPageSize) ? maxPageSize : value;
    }
}