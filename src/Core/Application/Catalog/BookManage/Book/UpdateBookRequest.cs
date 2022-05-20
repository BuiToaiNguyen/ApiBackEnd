namespace TD.CitizenAPI.Application.Catalog.BookManage;

public class UpdateBookRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
    public string NameBook { get; set; } = default!;
    public string? CodeBook { get; set; }
    public string? Description { get; set; }

    public float? Price { get; set; }
    public string? Image { get; set; }
    public Guid? AuthorId { get; set; }
    public Guid? CategoryId { get; set; }

}

public class UpdateBookRequestValidator : CustomValidator<UpdateBookRequest>
{
    public UpdateBookRequestValidator(IRepository<Book> repository, IStringLocalizer<UpdateBookRequestValidator> localizer) =>
        RuleFor(p => p.NameBook)
            .NotEmpty();
}

public class UpdateBookRequestHandler : IRequestHandler<UpdateBookRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Book> _repository;
    private readonly IStringLocalizer<UpdateBookRequestHandler> _localizer;

    public UpdateBookRequestHandler(IRepositoryWithEvents<Book> repository, IStringLocalizer<UpdateBookRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(UpdateBookRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(string.Format(_localizer["Book.notfound"], request.Id));

        item.Update(request.NameBook, request.CodeBook, request.Description, request.AuthorId, request.Price, request.CategoryId, request.Image);

        await _repository.UpdateAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}