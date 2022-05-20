namespace TD.CitizenAPI.Application.Catalog.BookManage;

public class GetAuthorBookRequest : IRequest<Result<AuthorBookDetailsDto>>
{
    public Guid Id { get; set; }

    public GetAuthorBookRequest(Guid id) => Id = id;
}

public class AuthorBookByIdSpec : Specification<AuthorBook, AuthorBookDetailsDto>, ISingleResultSpecification
{
    public AuthorBookByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetAuthorBookRequestHandler : IRequestHandler<GetAuthorBookRequest, Result<AuthorBookDetailsDto>>
{
    private readonly IRepository<AuthorBook> _repository;
    private readonly IStringLocalizer<GetAuthorBookRequestHandler> _localizer;

    public GetAuthorBookRequestHandler(IRepository<AuthorBook> repository, IStringLocalizer<GetAuthorBookRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<AuthorBookDetailsDto>> Handle(GetAuthorBookRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<AuthorBook, AuthorBookDetailsDto>)new AuthorBookByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["AuthorBook.notfound"], request.Id));
        return Result<AuthorBookDetailsDto>.Success(item);

    }
}