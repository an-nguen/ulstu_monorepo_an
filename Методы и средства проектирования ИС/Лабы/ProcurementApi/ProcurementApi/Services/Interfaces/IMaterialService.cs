using ProcurementApi.Core.Domains;
using ProcurementApi.Core.Interfaces;

namespace ProcurementApi.Services.Interfaces;

public interface IMaterialService : IService<Material>
{
    public Task<IList<Material>> FindByName(string name);
    public Task<IList<Material>> FindByArticle(string name);
    public Task<int> GetStockLevel(Guid materialId);
    public Task SetStockLevel(Guid materialId, int stockLevel);
    public Task<IDocument> GetRequiredAmountOfMaterials();
}