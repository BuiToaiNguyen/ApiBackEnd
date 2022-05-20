namespace TD.CitizenAPI.Application.Catalog.BookManage;

public class SearchBookRequest : PaginationFilter, IRequest<PaginationResponse<BookDto>>
{


}

public class BookBySearchRequestSpec : EntitiesByPaginationFilterSpec<Book, BookDto>
{
    public BookBySearchRequestSpec(SearchBookRequest request)
        : base(request) =>
        Query.OrderBy(c => c.NameBook, !request.HasOrderBy());
}

public class SearchBookRequestHandler : IRequestHandler<SearchBookRequest, PaginationResponse<BookDto>>
{
    private readonly IReadRepository<Book> _repository;

    public SearchBookRequestHandler(IReadRepository<Book> repository) => _repository = repository;

    public async Task<PaginationResponse<BookDto>> Handle(SearchBookRequest request, CancellationToken cancellationToken)
    {
        var spec = new BookBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<BookDto>(list, count, request.PageNumber, request.PageSize);
    }
}