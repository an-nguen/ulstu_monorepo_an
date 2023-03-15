using Microsoft.AspNetCore.Mvc;
using NodaTime;
using ProcurementApi.Core.Domains;

namespace ProcurementApi.Controllers.Interface;

public interface IPurchaseController: IApiBaseController<Purchase>
{
    public Task<IActionResult> GetPlan(YearMonth date);
}