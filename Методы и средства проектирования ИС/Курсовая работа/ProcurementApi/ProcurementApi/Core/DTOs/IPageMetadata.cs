namespace ProcurementApi.Core.DTOs;

public interface IPageMetadata
{
    public int GetPageNumber();
    public int GetPageSize();
    public bool HasNext();
    public bool HasPrev();
}