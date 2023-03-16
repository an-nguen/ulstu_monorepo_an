using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProcurementApi.Controllers.Interfaces;
using ProcurementApi.Core.DTOs;
using ProcurementApi.Repositories.Interfaces;

namespace ProcurementApi.Controllers;

public abstract class AbstractController<TItem> : ControllerBase, IApiController<TItem>
    where TItem : class
{
    protected readonly ICrudRepository<TItem> _repository;

    protected AbstractController(ICrudRepository<TItem> repository)
    {
        _repository = repository;
    }

    public async Task<ActionResult<IPage<TItem>>> FetchPage(int page)
    {
        var entities = await _repository.GetEntities(page, Constants.DefaultPageSize);
        var response = PageResponse<TItem>.Builder.Create().SetItems(entities).SetPageNumber(page)
            .SetPageSize(Constants.DefaultPageSize).Build();
        return Ok(response);
    }

    public async Task<ActionResult<TItem>> GetById(string id)
    {
        if (!Guid.TryParse(id, out var guid))
            return BadRequest();
        var found = await _repository.GetEntityById(guid);
        return Ok(found);
    }

    public Task<ActionResult<TItem>> Create(TItem item)
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult<TItem>> Update(TItem item)
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult<DeleteResponse>> Delete(string id)
    {
        throw new NotImplementedException();
    }
}