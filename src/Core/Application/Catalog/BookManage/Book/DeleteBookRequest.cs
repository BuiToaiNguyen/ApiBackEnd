namespace TD.CitizenAPI.Application.Catalog.BookManage;

public class DeleteBookRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    public DeleteBookRequest(Guid id) => Id = id;
}

public class DeleteBookRequestHandler : IRequestHandler<DeleteBookRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Book> _repo;
    private readonly IStringLocalizer<DeleteBookRequestHandler> _localizer;

    public DeleteBookRequestHandler(IRepositoryWithEvents<Book> repo, IStringLocalizer<DeleteBookRequestHandler> localizer) =>
        (_repo, _localizer) = (repo, localizer);

    public async Task<Result<Guid>> Handle(DeleteBookRequest request, CancellationToken cancellationToken)
    {


        var item = await _repo.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(_localizer["Book.notfound"]);

        await _repo.DeleteAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}




