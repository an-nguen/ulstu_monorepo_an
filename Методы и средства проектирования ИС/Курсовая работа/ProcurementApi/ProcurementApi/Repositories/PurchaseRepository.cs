using NodaTime;
using ProcurementApi.Core.Domains;
using ProcurementApi.Repositories.Interfaces;

namespace ProcurementApi.Repositories;

public class PurchaseRepository: IPurchaseRepository
{
    private readonly AppDbContext _dbContext;

    public PurchaseRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<IEnumerable<Purchase>> GetEntities(int pageNumber, int pageSize)
    {
        throw new NotImplementedException();
    }

    public Task<Purchase> GetEntityById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Purchase> Create(Purchase product)
    {
        throw new NotImplementedException();
    }

    public Task<Purchase> Update(Guid id, Purchase product)
    {
        throw new NotImplementedException();
    }

    public Task Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Purchase>> GetReceiptListByDate(ZonedDateTime start, ZonedDateTime end)
    {
        throw new NotImplementedException();
    }
}