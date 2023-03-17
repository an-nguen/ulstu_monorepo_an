using Microsoft.AspNetCore.Mvc;
using NodaTime;
using ProcurementApi.Core.Domains;
using ProcurementApi.Core.Interfaces;

namespace ProcurementApi.Controllers.Interfaces;

public interface IPurchaseController : IApiController<Purchase>
{
    public Task<ActionResult<IList<Purchase>>> GetPurchasesBySupplier(string supplierId);
    public Task<ActionResult<IDocument>> GetProcurementPlan(YearMonth date);
}