namespace TD.CitizenAPI.Application.Catalog.BookManage;

public class DeleteAuthorBookRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    public DeleteAuthorBookRequest(Guid id) => Id = id;
}

public class DeleteAuthorBookRequestHandler : IRequestHandler<DeleteAuthorBookRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<AuthorBook> _repo;
    private readonly IStringLocalizer<DeleteAuthorBookRequestHandler> _localizer;

    public DeleteAuthorBookRequestHandler(IRepositoryWithEvents<AuthorBook> repo, IStringLocalizer<DeleteAuthorBookRequestHandler> localizer) =>
        (_repo, _localizer) = (repo, localizer);

    public async Task<Result<Guid>> Handle(DeleteAuthorBookRequest request, CancellationToken cancellationToken)
    {


        var item = await _repo.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(_localizer["AuthorBook.notfound"]);

        await _repo.DeleteAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}




