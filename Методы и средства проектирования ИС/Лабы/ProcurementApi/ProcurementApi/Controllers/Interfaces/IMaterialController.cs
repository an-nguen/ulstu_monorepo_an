using Microsoft.AspNetCore.Mvc;
using ProcurementApi.Core.Domains;
using ProcurementApi.Core.DTOs;
using ProcurementApi.Core.Interfaces;

namespace ProcurementApi.Controllers.Interfaces;

public interface IMaterialController : IApiController<Material>
{
    public Task<ActionResult<IList<Material>>> Filter(MaterialProperties props);
    public Task<IActionResult> GetStockLevel(string materialId);
    public Task<IActionResult> SetStockLevel(string materialId, int stockLevel);
    public Task<ActionResult<IDocument>> GetRequiredAmountOfMaterials();
}