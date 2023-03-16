using ProcurementApi.Core.Domains;
using ProcurementApi.Repositories.Interfaces;

namespace ProcurementApi.Repositories;

public class CompositionRepository: ICompositionRepository
{
    private readonly AppDbContext _dbContext;

    public CompositionRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<IEnumerable<Composition>> GetEntities(int pageNumber, int pageSize)
    {
        throw new NotImplementedException();
    }

    public Task<Composition> GetEntityById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Composition> Create(Composition product)
    {
        throw new NotImplementedException();
    }

    public Task<Composition> Update(Guid id, Composition product)
    {
        throw new NotImplementedException();
    }

    public Task Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}