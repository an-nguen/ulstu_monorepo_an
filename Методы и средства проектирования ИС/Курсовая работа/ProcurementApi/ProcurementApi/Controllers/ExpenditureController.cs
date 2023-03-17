using Microsoft.AspNetCore.Mvc;
using ProcurementApi.Controllers.Interfaces;
using ProcurementApi.Core.Domains;
using ProcurementApi.Core.DTOs;

namespace ProcurementApi.Controllers;

public class ExpenditureController: IExpenditureController
{
    public Task<ActionResult<IPage<Expenditure>>> FetchPage(int page)
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult<Expenditure>> GetById(string id)
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult<Expenditure>> Create(Expenditure item)
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult<Expenditure>> Update(Expenditure item)
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult<DeleteResponse>> Delete(string id)
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult<IList<Expenditure>>> GetByAuthorId(string userId)
    {
        throw new NotImplementedException();
    }
}