using Microsoft.AspNetCore.Mvc;
using ProcurementApi.Core.Domains;

namespace ProcurementApi.Controllers.Interfaces;

public interface ISupplierController: IApiController<Supplier>
{
    public Task<ActionResult<IList<Material>>> GetPurchasedMaterials(string supplierId);
}