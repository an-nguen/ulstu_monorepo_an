using System.ComponentModel.DataAnnotations;
using ProcurementApi.Core.Interfaces;
using static System.String;

namespace ProcurementApi.Core.Domains;

/// <summary>
/// Domain class EndProduct - готовая продукция 
/// </summary>
public class Product: IProduct
{
    [Key]
    public Guid Id { get; set; }
    public string Article { get; set; } = Empty;
    [MaxLength(500)]
    public required string Name { get; set; } = Empty;
    [MaxLength(8000)]
    public string Description { get; set; } = Empty;

    public List<Composition> Compositions { get; set; } = null!;
}