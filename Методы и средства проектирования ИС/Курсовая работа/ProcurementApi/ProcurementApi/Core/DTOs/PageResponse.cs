namespace ProcurementApi.Core.DTOs;

public class PageResponse<TItem>: IPage<TItem>
    where TItem : class
{
    private PageResponse()
    {
    }

    private PageResponse(IEnumerable<TItem> items, IPageMetadata metadata)
    {
        _items = items;
        _metadata = metadata;
    }

    private IEnumerable<TItem> _items = null!;
    private IPageMetadata _metadata = null!;

    public class Builder
    {
        private readonly List<TItem> _items = new();
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
            new(_items, new PageMetadata
            {
                PageNumber = _pageNumber,
                PageSize = _pageSize
            });
    }

    public IEnumerable<TItem> GetItems() => _items;
    public IPageMetadata GetMetadata() => _metadata;
}