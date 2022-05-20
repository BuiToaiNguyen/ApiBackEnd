namespace TD.CitizenAPI.Application.Catalog.BookManage;

public class GetBookRequest : IRequest<Result<BookDetailsDto>>
{
    public Guid Id { get; set; }

    public GetBookRequest(Guid id) => Id = id;
}

public class BookByIdSpec : Specification<Book, BookDetailsDto>, ISingleResultSpecification
{
    public BookByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetBookRequestHandler : IRequestHandler<GetBookRequest, Result<BookDetailsDto>>
{
    private readonly IRepository<Book> _repository;
    private readonly IStringLocalizer<GetBookRequestHandler> _localizer;

    public GetBookRequestHandler(IRepository<Book> repository, IStringLocalizer<GetBookRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<BookDetailsDto>> Handle(GetBookRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<Book, BookDetailsDto>)new BookByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["Book.notfound"], request.Id));
        return Result<BookDetailsDto>.Success(item);

    }
}