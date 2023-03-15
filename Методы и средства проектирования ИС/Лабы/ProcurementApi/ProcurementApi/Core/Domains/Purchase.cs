using ProcurementApi.Core.Interfaces;

namespace ProcurementApi.Core.Domains;

/// <summary>
/// Domain class PurchaseReceipt - Приходная накладная
/// </summary>
public class Purchase: AbstractDocument, IPurchase
{
    public Guid SupplierId { get; set; }
    public ISupplier Supplier { get; set; } = null!;
    public IList<IProduct> Products { get; set; } = null!;
    public IList<IProduct> Materials { get; set; } = null!;
}