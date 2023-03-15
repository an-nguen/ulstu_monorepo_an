namespace ProcurementApi.Core.Interfaces;

public interface ISupplier
{
    public string ShortName { get; set; }

    public string FullName { get; set; }

    // ИНН
    public string TaxIdentificationNumber { get; set; }
}