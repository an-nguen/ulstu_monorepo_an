namespace ProcurementApi.Core.DTOs;

public class PageMetadata: IPageMetadata
{
    public int PageNumber { get; set; } = 0;
    public int PageSize { get; set; } = 0;
    public int GetPageNumber() => PageNumber;

    public int GetPageSize() => PageSize;

    public bool HasNext() => false;

    public bool HasPrev() => false;
}