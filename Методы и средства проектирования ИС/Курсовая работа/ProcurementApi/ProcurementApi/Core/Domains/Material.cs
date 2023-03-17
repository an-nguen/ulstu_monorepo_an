using System.ComponentModel.DataAnnotations;
using ProcurementApi.Core.Interfaces;
using static System.String;

namespace ProcurementApi.Core.Domains;

/// <summary>
/// Domain class RawMaterial - the materials that intended for production of end products
/// </summary>
public class Material : IProduct
{
    [Key] public Guid Id { get; set; }
    public string Article { get; set; } = Empty;
    [MaxLength(500)] public required string Name { get; set; } = Empty;
    [MaxLength(8000)] public string Description { get; set; } = Empty;

    public string ProductUnit { get; set; } = Empty;

    // Нормы запасов
    public int StockLevel { get; set; }
}