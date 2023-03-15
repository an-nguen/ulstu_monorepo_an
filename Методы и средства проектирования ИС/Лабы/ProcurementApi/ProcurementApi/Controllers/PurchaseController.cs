using Microsoft.AspNetCore.Mvc;
using NodaTime;
using ProcurementApi.Controllers.Interface;
using ProcurementApi.Core.Domains;
using ProcurementApi.Services.Interfaces;

namespace ProcurementApi.Controllers;

[ApiController]
[Route("/purchases")]
public class PurchaseController: DefaultController<Purchase, IPurchaseService>, IPurchaseController
{
    public PurchaseController(IPurchaseService service) : base(service)
    {
    }

    public Task<IActionResult> GetPlan(YearMonth date)
    {
        throw new NotImplementedException();
    }
}