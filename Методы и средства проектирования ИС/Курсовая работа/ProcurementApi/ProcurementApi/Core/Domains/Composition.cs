using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProcurementApi.Core.Domains;

/// <summary>
/// Domain class ProductComposition - Состав готовой продукции
/// </summary>
public class Composition
{
    [Key] public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    [ForeignKey(nameof(ProductId))] public Product Product { get; set; }
    public Guid MaterialId { get; set; }
    [ForeignKey(nameof(MaterialId))] public Material Material { get; set; }
    public decimal Quantity { get; set; }
}