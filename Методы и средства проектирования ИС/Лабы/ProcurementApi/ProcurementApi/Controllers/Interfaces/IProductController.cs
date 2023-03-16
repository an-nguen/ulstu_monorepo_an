using Microsoft.AspNetCore.Mvc;
using ProcurementApi.Core.Domains;

namespace ProcurementApi.Controllers.Interfaces;

public interface IProductController: IApiController<Product>
{
    public Task<ActionResult<IList<Composition>>> GetCompositions(string productId);
}