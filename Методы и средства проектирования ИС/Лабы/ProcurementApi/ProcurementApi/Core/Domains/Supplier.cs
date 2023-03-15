using ProcurementApi.Core.Interfaces;
using static System.String;

namespace ProcurementApi.Core.Domains;

public class Supplier: ISupplier
{
    public Guid Id { get; set; }
    public required string ShortName { get; set; }
    public string FullName { get; set; } = Empty;
    // ИНН
    public string TaxIdentificationNumber { get; set; } = Empty;
}