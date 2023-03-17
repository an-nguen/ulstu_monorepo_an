using Microsoft.AspNetCore.Mvc;
using ProcurementApi.Core.DTOs;

namespace ProcurementApi.Controllers.Interfaces;

public interface IApiController<TItem>
    where TItem : class
{
    public Task<ActionResult<IPage<TItem>>> FetchPage(int page);
    public Task<ActionResult<TItem>> GetById(string id);
    public Task<ActionResult<TItem>> Create(TItem item);
    public Task<ActionResult<TItem>> Update(TItem item);
    public Task<ActionResult<DeleteResponse>> Delete(string id);
}