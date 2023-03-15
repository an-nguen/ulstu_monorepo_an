using NodaTime;
using ProcurementApi.Core.Domains;

namespace ProcurementApi.Repositories.Interfaces;

public interface IPurchaseRepository: IRepository<Purchase>
{
    public Task<List<Purchase>> GetReceiptListByDateRange(ZonedDateTime start, ZonedDateTime end);
}