namespace ProcurementApi.Core.Interfaces;

public interface IDocumentLine
{
    public Guid ProductId { get; set; }
    public decimal Price { get; set; }
    public decimal Quantity { get; set; }

    public decimal GetTotal();
}