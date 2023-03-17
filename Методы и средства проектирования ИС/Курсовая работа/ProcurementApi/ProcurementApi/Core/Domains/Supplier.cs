using System.ComponentModel.DataAnnotations;
using static System.String;

namespace ProcurementApi.Core.Domains;

public class Supplier
{
    [Key] public Guid Id { get; set; }
    public required string Name { get; set; }
    public string FullName { get; set; } = Empty;
    // ИНН
    public string TaxIdentificationNumber { get; set; } = Empty;
}