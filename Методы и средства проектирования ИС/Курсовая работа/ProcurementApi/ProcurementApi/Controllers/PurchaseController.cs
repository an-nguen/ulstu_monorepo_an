using Microsoft.AspNetCore.Mvc;
using NodaTime;
using ProcurementApi.Controllers.Interfaces;
using ProcurementApi.Core.Domains;
using ProcurementApi.Core.DTOs;
using ProcurementApi.Core.Interfaces;

namespace ProcurementApi.Controllers;

[ApiController]
[Route("/purchases")]
public class PurchaseController: IPurchaseController
{
    public Task<ActionResult<IPage<Purchase>>> FetchPage(int page)
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult<Purchase>> GetById(string id)
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult<Purchase>> Create(Purchase item)
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult<Purchase>> Update(Purchase item)
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult<DeleteResponse>> Delete(string id)
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult<IList<Purchase>>> GetPurchasesBySupplier(string supplierId)
    {
        throw new NotImplementedException();
    }

    Task<ActionResult<IDocument>> IPurchaseController.GetProcurementPlan(YearMonth date)
    {
        throw new NotImplementedException();
    }

    public Task<IDocument> GetProcurementPlan(YearMonth date)
    {
        throw new NotImplementedException();
    }
}