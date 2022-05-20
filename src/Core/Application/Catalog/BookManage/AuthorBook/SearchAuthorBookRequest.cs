namespace TD.CitizenAPI.Application.Catalog.BookManage;

public class SearchAuthorBooksRequest : PaginationFilter, IRequest<PaginationResponse<AuthorBookDto>>
{


}

public class AuthorBooksBySearchRequestSpec : EntitiesByPaginationFilterSpec<AuthorBook, AuthorBookDto>
{
    public AuthorBooksBySearchRequestSpec(SearchAuthorBooksRequest request)
        : base(request) =>
        Query.OrderBy(c => c.NameAuthor, !request.HasOrderBy());
}

public class SearchAuthorBooksRequestHandler : IRequestHandler<SearchAuthorBooksRequest, PaginationResponse<AuthorBookDto>>
{
    private readonly IReadRepository<AuthorBook> _repository;

    public SearchAuthorBooksRequestHandler(IReadRepository<AuthorBook> repository) => _repository = repository;

    public async Task<PaginationResponse<AuthorBookDto>> Handle(SearchAuthorBooksRequest request, CancellationToken cancellationToken)
    {
        var spec = new AuthorBooksBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<AuthorBookDto>(list, count, request.PageNumber, request.PageSize);
    }
}