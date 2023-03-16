using ProcurementApi.Core.Domains;
using ProcurementApi.Repositories.Interfaces;

namespace ProcurementApi.Repositories;

public class ProductRepository: IProductRepository
{
    private readonly AppDbContext _dbContext;
    
    public ProductRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public Task<IEnumerable<Product>> GetEntities(int pageNumber, int pageSize)
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetEntityById(Guid id)
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