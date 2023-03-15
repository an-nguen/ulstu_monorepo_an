using NodaTime;
using ProcurementApi.Core.Domains;
using ProcurementApi.Core.Interfaces;

namespace ProcurementApi.Services.Interfaces;

public interface IPurchaseService : IService<Purchase>
{
    public Task<IDocument> GetProcurementPlan(YearMonth date);
}