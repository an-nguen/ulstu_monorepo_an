using ProcurementApi.Core.Domains;
using ProcurementApi.Repositories.Interfaces;

namespace ProcurementApi.Repositories;

public class EndProductRepository: IEndProductRepository
{
    private readonly AppDbContext _dbContext;
    
    public EndProductRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public Task<IEnumerable<Product>> GetEntities(int pageNumber, int pageSize)
    {
        throw new NotImplementedException();
    }

    public Task<Product> Create(Product product)
    {
        throw new NotImplementedException();
    }

    public Task<Product> Update(Guid id, Product product)
    {
        throw new NotImplementedException();
    }

    public Task Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}