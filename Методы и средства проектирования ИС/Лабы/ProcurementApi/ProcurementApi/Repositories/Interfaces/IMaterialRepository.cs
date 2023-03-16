using ProcurementApi.Core.Domains;

namespace ProcurementApi.Repositories.Interfaces;

public interface IMaterialRepository: ICrudRepository<Material>
{
    public IList<Material> FilterByName(string pattern);
}