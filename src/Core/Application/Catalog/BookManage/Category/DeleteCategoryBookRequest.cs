namespace TD.CitizenAPI.Application.Catalog.BookManage;

public class DeleteCategoryBookRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    public DeleteCategoryBookRequest(Guid id) => Id = id;
}

public class DeleteCategoryBookRequestHandler : IRequestHandler<DeleteCategoryBookRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<CategoryBook> _repo;
    private readonly IStringLocalizer<DeleteCategoryBookRequestHandler> _localizer;

    public DeleteCategoryBookRequestHandler(IRepositoryWithEvents<CategoryBook> repo, IStringLocalizer<DeleteCategoryBookRequestHandler> localizer) =>
        (_repo, _localizer) = (repo, localizer);

    public async Task<Result<Guid>> Handle(DeleteCategoryBookRequest request, CancellationToken cancellationToken)
    {


        var item = await _repo.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(_localizer["CategoryBook.notfound"]);

        await _repo.DeleteAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}




