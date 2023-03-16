using ProcurementApi.Core.Domains;
using ProcurementApi.Repositories.Interfaces;

namespace ProcurementApi.Repositories;

public class ExpenditureRepository: IExpenditureRepository
{
    public Task<IEnumerable<Expenditure>> GetEntities(int pageNumber, int pageSize)
    {
        throw new NotImplementedException();
    }

    public Task<Expenditure> GetEntityById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Expenditure> Create(Expenditure product)
    {
        throw new NotImplementedException();
    }

    public Task<Expenditure> Update(Guid id, Expenditure product)
    {
        throw new NotImplementedException();
    }

    public Task Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}