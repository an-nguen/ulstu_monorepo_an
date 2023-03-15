using Microsoft.AspNetCore.Mvc;
using ProcurementApi.Controllers.Interface;
using ProcurementApi.Core.Domains;
using ProcurementApi.Core.DTOs;
using ProcurementApi.Services.Interfaces;

namespace ProcurementApi.Controllers;

[ApiController]
[Route("/materials")]
public class MaterialController: DefaultController<Material, IMaterialService>, IMaterialController
{
    public MaterialController(IMaterialService service) : base(service)
    {
    }

    public Task<IActionResult> GetByProperty(MaterialProperties props)
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult<int>> GetStockLevel(Guid materialId)
    {
        throw new NotImplementedException();
    }

    public Task<IActionResult> SetStockLevel(Guid materialId, int stockLevel)
    {
        throw new NotImplementedException();
    }

    public Task<IActionResult> GetRequiredAmountOfMaterials()
    {
        throw new NotImplementedException();
    }
}