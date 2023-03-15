namespace ProcurementApi.Core.Interfaces;

public interface IPurchase
{
    public Guid SupplierId { get; set; }
    public ISupplier Supplier { get; set; }
    public IList<IProduct> Products { get; set; }
    public IList<IProduct> Materials { get; set; }
}