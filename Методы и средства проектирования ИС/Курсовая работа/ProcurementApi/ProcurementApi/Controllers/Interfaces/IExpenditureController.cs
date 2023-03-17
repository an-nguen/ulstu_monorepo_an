using Microsoft.AspNetCore.Mvc;
using ProcurementApi.Core.Domains;

namespace ProcurementApi.Controllers.Interfaces;

public interface IExpenditureController: IApiController<Expenditure>
{
    public Task<ActionResult<IList<Expenditure>>> GetByAuthorId(string userId);
}