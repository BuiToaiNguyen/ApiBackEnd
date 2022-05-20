namespace TD.CitizenAPI.Application.Catalog.BookManage;

public class UpdateAuthorBookRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
    public string NameAuthor { get; set; } = default!;
    public string? Code { get; set; }

    public string? Description { get; set; }

    public int? Age { get; set; }
    public string? Image { get; set; }

    public string? Address { get; set; }

}

public class UpdateAuthorBookRequestValidator : CustomValidator<UpdateAuthorBookRequest>
{
    public UpdateAuthorBookRequestValidator(IRepository<AuthorBook> repository, IStringLocalizer<UpdateAuthorBookRequestValidator> localizer) =>
        RuleFor(p => p.NameAuthor
        )
            .NotEmpty();
}

public class UpdateAuthorBookRequestHandler : IRequestHandler<UpdateAuthorBookRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<AuthorBook> _repository;
    private readonly IStringLocalizer<UpdateAuthorBookRequestHandler> _localizer;

    public UpdateAuthorBookRequestHandler(IRepositoryWithEvents<AuthorBook> repository, IStringLocalizer<UpdateAuthorBookRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(UpdateAuthorBookRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(string.Format(_localizer["AuthorBook.notfound"], request.Id));

        item.Update(request.NameAuthor, request.Code, request.Description, request.Age, request.Address, request.Image);

        await _repository.UpdateAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}