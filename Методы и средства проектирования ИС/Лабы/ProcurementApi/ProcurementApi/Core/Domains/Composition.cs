using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProcurementApi.Core.Domains;

/// <summary>
/// Domain class ProductComposition - Состав готовой продукции
/// </summary>
public class Composition
{
    [Key] public Guid Id { get; set; }
    public Guid EndProductId { get; set; }
    [ForeignKey(nameof(EndProductId))] public Product Product { get; set; }
    public Guid RawMaterialId { get; set; }
    [ForeignKey(nameof(RawMaterialId))] public Material Material { get; set; }
    public decimal Quantity { get; set; }
}