using Microsoft.AspNetCore.Mvc;
using ProcurementApi.Controllers.Interfaces;
using ProcurementApi.Core.Domains;
using ProcurementApi.Core.DTOs;
using ProcurementApi.Core.Interfaces;

namespace ProcurementApi.Controllers;

[ApiController]
[Route("/materials")]
public class MaterialController: IMaterialController
{
    public Task<ActionResult<IPage<Material>>> FetchPage(int page)
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult<Material>> GetById(string id)
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult<Material>> Create(Material item)
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult<Material>> Update(Material item)
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult<DeleteResponse>> Delete(string id)
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult<IList<Material>>> Filter(MaterialProperties props)
    {
        throw new NotImplementedException();
    }

    public Task<IActionResult> GetStockLevel(string materialId)
    {
        throw new NotImplementedException();
    }

    public Task<IActionResult> SetStockLevel(string materialId, int stockLevel)
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult<IDocument>> GetRequiredAmountOfMaterials()
    {
        throw new NotImplementedException();
    }
}