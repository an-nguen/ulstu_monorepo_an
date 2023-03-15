using System.ComponentModel.DataAnnotations;
using NodaTime;
using ProcurementApi.Core.Interfaces;
using static System.String;

namespace ProcurementApi.Core.Domains;

public class AbstractDocument : IDocument
{
    [Key]
    public Guid Id { get; set; }
    public string Comment { get; set; } = Empty;
    public Guid AuthorId { get; set; }

    public IList<IDocumentLine> DocumentLines { get; set; } = null!;
    
    public ZonedDateTime CreatedAt { get; set; }
    public ZonedDateTime UpdatedAt { get; set; }
    
    public decimal GetTotal() => DocumentLines.Select(line => line.GetTotal()).Sum();
}