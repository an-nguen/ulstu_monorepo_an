using NodaTime;
using ProcurementApi.Core.Domains;

namespace ProcurementApi.Repositories.Interfaces;

public interface IPurchaseRepository: ICrudRepository<Purchase>
{
    public Task<List<Purchase>> GetReceiptListByDate(ZonedDateTime start, ZonedDateTime end);
}