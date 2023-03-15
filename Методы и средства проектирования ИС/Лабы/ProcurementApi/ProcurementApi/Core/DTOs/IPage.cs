namespace ProcurementApi.Core.DTOs;

public interface IPage<out TItem>
    where TItem : class
{
    public IEnumerable<TItem> GetItems();
}