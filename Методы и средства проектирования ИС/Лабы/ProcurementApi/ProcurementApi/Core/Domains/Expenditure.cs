using static System.String;

namespace ProcurementApi.Core.Domains;

/// <summary>
/// Domain class GoodsIssue - документ расходной накладной 
/// </summary>
public class Expenditure: AbstractDocument
{
    public string Purpose { get; set; } = Empty;
}