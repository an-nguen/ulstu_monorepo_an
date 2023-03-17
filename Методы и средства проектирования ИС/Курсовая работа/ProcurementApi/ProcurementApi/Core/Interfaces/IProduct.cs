using System.ComponentModel.DataAnnotations;

namespace ProcurementApi.Core.Interfaces;

public interface IProduct
{
    public string Article { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}