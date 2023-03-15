using Microsoft.AspNetCore.Mvc;
using ProcurementApi.Controllers.Interface;
using ProcurementApi.Core.DTOs;
using ProcurementApi.Services.Interfaces;

namespace ProcurementApi.Controllers;

public abstract class DefaultController<TItem, TService> : ControllerBase, IApiBaseController<TItem>
    where TItem : class
    where TService : IService<TItem>
{
    protected readonly TService _service;

    protected DefaultController(TService service)
    {
        _service = service;
    }

    public Task<ActionResult<TItem>> GetById(string id)
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult<IPage<TItem>>> GetPage(int pageNumber)
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult<TItem>> Create(TItem item)
    {
        throw new NotImplementedException();
    }

    [HttpPut("{id}")]
    public Task<ActionResult<TItem>> Update(string id, TItem item)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{id:required}")]
    public async Task<IActionResult> Delete(string id)
    {
        var guid = Guid.Empty;
        if (!Guid.TryParse(id, out guid))
            return BadRequest();
        try
        {
            await _service.Delete(guid);
            return Ok(new DeleteResponse(true));
        }
        catch (Exception e)
        {
            return StatusCode(500, e.ToString());
        }
    }
}