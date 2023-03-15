using NodaTime;

namespace ProcurementApi.Core.Interfaces;

public interface IDocument
{
    public Guid AuthorId { get; set; }
    public string Comment { get; set; }
    
    public IList<IDocumentLine> DocumentLines { get; set; }
    public ZonedDateTime CreatedAt { get; set; }
    public ZonedDateTime UpdatedAt { get; set; }
    public decimal GetTotal();

}