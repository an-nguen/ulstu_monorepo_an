using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProcurementApi.Core.Interfaces;

namespace ProcurementApi.Core.Domains;

public class DocumentLine : IDocumentLine
{
    [Key] public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    [ForeignKey(nameof(ProductId))] public Product Product { get; set; }
    public decimal Price { get; set; }
    public decimal Quantity { get; set; }

    public decimal GetTotal()
        => Price * Quantity;
}