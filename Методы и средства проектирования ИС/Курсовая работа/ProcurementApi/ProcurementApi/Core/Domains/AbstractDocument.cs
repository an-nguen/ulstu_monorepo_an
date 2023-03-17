using System.ComponentModel.DataAnnotations;
using NodaTime;
using ProcurementApi.Core.Interfaces;

namespace ProcurementApi.Core.Domains;

public class AbstractDocument : IDocument
{
    [Key]
    public Guid Id { get; set; }

    public IList<IDocumentLine> DocumentLines { get; set; } = null!;
    
    public Guid AuthorId { get; set; }

    public ZonedDateTime CreatedAt { get; set; }
    public ZonedDateTime UpdatedAt { get; set; }

    public IList<IDocumentLine> GetDocumentLines() => DocumentLines;

    public decimal GetTotal() => DocumentLines.Select(line => line.GetTotal()).Sum();
}