using Microsoft.AspNetCore.Mvc;
using ProcurementApi.Core.DTOs;

namespace ProcurementApi.Controllers.Interface;

public interface IApiBaseController<TItem>
    where TItem: class
{
    public Task<ActionResult<TItem>> GetById(string id);
    public Task<ActionResult<IPage<TItem>>> GetPage(int pageNumber);
    public Task<ActionResult<TItem>> Create(TItem item);
    public Task<ActionResult<TItem>> Update(string id, TItem item);
    public Task<IActionResult> Delete(string id);
}