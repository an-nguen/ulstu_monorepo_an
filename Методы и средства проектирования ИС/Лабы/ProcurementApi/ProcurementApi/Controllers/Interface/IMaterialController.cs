using Microsoft.AspNetCore.Mvc;
using ProcurementApi.Core.Domains;
using ProcurementApi.Core.DTOs;

namespace ProcurementApi.Controllers.Interface;

public interface IMaterialController : IApiBaseController<Material>
{
    public Task<IActionResult> GetByProperty(MaterialProperties props);
    public Task<ActionResult<int>> GetStockLevel(Guid materialId);
    public Task<IActionResult> SetStockLevel(Guid materialId, int stockLevel);
    public Task<IActionResult> GetRequiredAmountOfMaterials();
}