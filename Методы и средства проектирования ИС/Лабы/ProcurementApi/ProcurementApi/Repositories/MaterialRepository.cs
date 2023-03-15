using ProcurementApi.Core.Domains;
using ProcurementApi.Repositories.Interfaces;

namespace ProcurementApi.Repositories;

public class MaterialRepository: IMaterialRepository
{
    private readonly AppDbContext _dbContext;
    
    public MaterialRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<IEnumerable<Material>> GetEntities(int pageNumber, int pageSize)
    {
        throw new NotImplementedException();
    }

    public Task<Material> Create(Material product)
    {
        throw new NotImplementedException();
    }

    public Task<Material> Update(Guid id, Material product)
    {
        throw new NotImplementedException();
    }

    public Task Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}