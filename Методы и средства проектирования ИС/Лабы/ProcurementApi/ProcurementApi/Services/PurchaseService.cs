using NodaTime;
using ProcurementApi.Core.Domains;
using ProcurementApi.Core.DTOs;
using ProcurementApi.Core.Interfaces;
using ProcurementApi.Repositories;
using ProcurementApi.Services.Interfaces;

namespace ProcurementApi.Services;

public class PurchaseService: IPurchaseService
{
    private readonly AppDbContext _dbContext;

    public PurchaseService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<IPage<Purchase>> GetPage(int pageNumber)
    {
        throw new NotImplementedException();
    }

    public Task<Purchase> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Purchase> Create(Purchase item)
    {
        throw new NotImplementedException();
    }

    public Task<Purchase> Update(Purchase item)
    {
        throw new NotImplementedException();
    }

    public Task Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IDocument> GetProcurementPlan(YearMonth date)
    {
        throw new NotImplementedException();
    }
}