using Microsoft.AspNetCore.Mvc;
using ProcurementApi.Controllers.Interfaces;
using ProcurementApi.Core.Domains;
using ProcurementApi.Core.DTOs;

namespace ProcurementApi.Controllers;

public class ProductController: IProductController
{
    public Task<ActionResult<IPage<Product>>> FetchPage(int page)
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult<Product>> GetById(string id)
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult<Product>> Create(Product item)
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult<Product>> Update(Product item)
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult<DeleteResponse>> Delete(string id)
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult<IList<Composition>>> GetCompositions(string productId)
    {
        throw new NotImplementedException();
    }
}