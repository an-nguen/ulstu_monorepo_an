using ProcurementApi.Core;

namespace ProcurementApi.Config;

public class ApiOptions
{
    public const string Api = "Api";

    public int PageSize { get; set; } = Constants.DefaultPageSize;
}