namespace TD.CitizenAPI.Application.Catalog.BookManage;

public partial class CreateAuthorBookRequest : IRequest<Result<Guid>>
{
    public string NameAuthor { get; set; } = default!;
    public string? Code { get; set; }

    public string? Description { get; set; }

    public int? Age { get; set; }
    public string? Image { get; set; }

    public string? Address { get; set; }

}

public class CreateAuthorBookRequestValidator : CustomValidator<CreateAuthorBookRequest>
{
    public CreateAuthorBookRequestValidator(IReadRepository<AuthorBook> repository, IStringLocalizer<CreateAuthorBookRequestValidator> localizer) =>
        RuleFor(p => p.NameAuthor).NotEmpty();
}

public class CreateAuthorBookRequestHandler : IRequestHandler<CreateAuthorBookRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<AuthorBook> _repository;

    public CreateAuthorBookRequestHandler(IRepositoryWithEvents<AuthorBook> repository) => _repository = repository;

    public async Task<Result<Guid>> Handle(CreateAuthorBookRequest request, CancellationToken cancellationToken)
    {
        var item = new AuthorBook(request.NameAuthor, request.Code, request.Description, request.Age, request.Address, request.Image);
        await _repository.AddAsync(item, cancellationToken);
        return Result<Guid>.Success(item.Id);
    }
}
