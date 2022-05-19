namespace TD.CitizenAPI.Application.Catalog.BookManage;

public class SearchCategoryBooksRequest : PaginationFilter, IRequest<PaginationResponse<CategoryBookDto>>
{


}

public class CategoryBooksBySearchRequestSpec : EntitiesByPaginationFilterSpec<CategoryBook, CategoryBookDto>
{
    public CategoryBooksBySearchRequestSpec(SearchCategoryBooksRequest request)
        : base(request) =>
        Query.OrderBy(c => c.NameCate, !request.HasOrderBy());
}

public class SearchCategoryBooksRequestHandler : IRequestHandler<SearchCategoryBooksRequest, PaginationResponse<CategoryBookDto>>
{
    private readonly IReadRepository<CategoryBook> _repository;

    public SearchCategoryBooksRequestHandler(IReadRepository<CategoryBook> repository) => _repository = repository;

    public async Task<PaginationResponse<CategoryBookDto>> Handle(SearchCategoryBooksRequest request, CancellationToken cancellationToken)
    {
        var spec = new CategoryBooksBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<CategoryBookDto>(list, count, request.PageNumber, request.PageSize);
    }
}