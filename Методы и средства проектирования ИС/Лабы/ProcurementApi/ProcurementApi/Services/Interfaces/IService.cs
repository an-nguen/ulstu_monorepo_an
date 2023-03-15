using ProcurementApi.Core.DTOs;

namespace ProcurementApi.Services.Interfaces;

public interface IService<TItem>
    where TItem : class
{
    public Task<IPage<TItem>> GetPage(int pageNumber);
    public Task<TItem> GetById(Guid id);
    public Task<TItem> Create(TItem item);
    public Task<TItem> Update(TItem item);
    public Task Delete(Guid id);
}