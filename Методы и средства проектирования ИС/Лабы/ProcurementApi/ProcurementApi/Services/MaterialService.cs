using ProcurementApi.Core.Domains;
using ProcurementApi.Core.DTOs;
using ProcurementApi.Core.Interfaces;
using ProcurementApi.Services.Interfaces;

namespace ProcurementApi.Services;

public class MaterialService: IMaterialService
{
    public Task<IPage<Material>> GetPage(int pageNumber)
    {
        throw new NotImplementedException();
    }

    public Task<Material> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Material> Create(Material item)
    {
        throw new NotImplementedException();
    }

    public Task<Material> Update(Material item)
    {
        throw new NotImplementedException();
    }

    public Task Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IList<Material>> FindByName(string name)
    {
        throw new NotImplementedException();
    }

    public Task<IList<Material>> FindByArticle(string name)
    {
        throw new NotImplementedException();
    }
    
    public Task<int> GetStockLevel(Guid materialId)
    {
        throw new NotImplementedException();
    }

    public Task SetStockLevel(Guid materialId, int stockLevel)
    {
        throw new NotImplementedException();
    }

    public Task<IDocument> GetRequiredAmountOfMaterials()
    {
        throw new NotImplementedException();
    }
}