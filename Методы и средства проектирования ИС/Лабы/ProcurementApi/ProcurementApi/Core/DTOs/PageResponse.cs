namespace ProcurementApi.Core.DTOs;

public class PageResponse<TItem>
    where TItem : class
{
    private PageResponse()
    {
    }

    public PageResponse(IEnumerable<TItem> items, PageMetadata metadata)
    {
        Items = items;
        Metadata = metadata;
    }

    public IEnumerable<TItem> Items { get; } = null!;
    public PageMetadata Metadata { get; } = null!;

    public class Builder
    {
        private List<TItem> _items = new();
        private int _pageSize;
        private int _pageNumber;

        public static Builder Create() => new();

        public Builder SetItems(IEnumerable<TItem> items)
        {
            _items.AddRange(items);
            return this;
        }

        public Builder SetPageSize(int pageSize)
        {
            _pageSize = pageSize;
            return this;
        }

        public Builder SetPageNumber(int page)
        {
            _pageNumber = page;
            return this;
        }

        public PageResponse<TItem> Build() =>
            new PageResponse<TItem>(_items, new PageMetadata
            {
                PageNumber = _pageNumber,
                PageSize = _pageSize
            });
    }
}