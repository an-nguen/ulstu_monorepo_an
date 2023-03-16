using Microsoft.AspNetCore.Mvc;
using ProcurementApi.Controllers.Interfaces;
using ProcurementApi.Core.Domains;
using ProcurementApi.Core.DTOs;

namespace ProcurementApi.Controllers;

[ApiController]
public class SupplierController: ISupplierController
{
    public Task<ActionResult<IPage<Supplier>>> FetchPage(int page)
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult<Supplier>> GetById(string id)
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult<Supplier>> Create(Supplier item)
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult<Supplier>> Update(Supplier item)
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult<DeleteResponse>> Delete(string id)
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult<IList<Material>>> GetPurchasedMaterials(string supplierId)
    {
        throw new NotImplementedException();
    }
}