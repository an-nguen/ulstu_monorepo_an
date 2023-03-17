using NodaTime;

namespace ProcurementApi.Core.Interfaces;

public interface IDocument
{
    public IList<IDocumentLine> GetDocumentLines();
    public decimal GetTotal();

}