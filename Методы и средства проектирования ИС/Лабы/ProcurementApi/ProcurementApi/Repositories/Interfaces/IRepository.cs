namespace ProcurementApi.Repositories.Interfaces;

public interface IRepository<TEntity>
    where TEntity : class
{
    public Task<IEnumerable<TEntity>> GetEntities(int pageNumber, int pageSize);
    public Task<TEntity> Create(TEntity product);
    public Task<TEntity> Update(Guid id, TEntity product);
    public Task Delete(Guid id);
}