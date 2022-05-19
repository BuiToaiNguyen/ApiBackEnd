namespace TD.CitizenAPI.Application.Catalog.BookManage;

public class GetCategoryBookRequest : IRequest<Result<CategoryBookDetailsDto>>
{
    public Guid Id { get; set; }

    public GetCategoryBookRequest(Guid id) => Id = id;
}

public class CategoryBookByIdSpec : Specification<CategoryBook, CategoryBookDetailsDto>, ISingleResultSpecification
{
    public CategoryBookByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetCategoryBookRequestHandler : IRequestHandler<GetCategoryBookRequest, Result<CategoryBookDetailsDto>>
{
    private readonly IRepository<CategoryBook> _repository;
    private readonly IStringLocalizer<GetCategoryBookRequestHandler> _localizer;

    public GetCategoryBookRequestHandler(IRepository<CategoryBook> repository, IStringLocalizer<GetCategoryBookRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<CategoryBookDetailsDto>> Handle(GetCategoryBookRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<CategoryBook, CategoryBookDetailsDto>)new CategoryBookByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["CategoryBook.notfound"], request.Id));
        return Result<CategoryBookDetailsDto>.Success(item);

    }
}