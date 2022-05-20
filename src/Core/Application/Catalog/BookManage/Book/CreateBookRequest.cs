namespace TD.CitizenAPI.Application.Catalog.BookManage;

public partial class CreateBookRequest : IRequest<Result<Guid>>
{
    public string NameBook { get; set; } = default!;
    public string? CodeBook { get; set; }
    public string? Description { get; set; }

    public float? Price { get; set; }
    public string? Image { get; set; }
    public Guid? AuthorId { get; set; }
    public Guid? CategoryId { get; set; }


}

public class CreateBookRequestValidator : CustomValidator<CreateBookRequest>
{
    public CreateBookRequestValidator(IReadRepository<Book> repository, IStringLocalizer<CreateBookRequestValidator> localizer) =>
        RuleFor(p => p.NameBook).NotEmpty();
}

public class CreateBookRequestHandler : IRequestHandler<CreateBookRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Book> _repository;

    public CreateBookRequestHandler(IRepositoryWithEvents<Book> repository) => _repository = repository;

    public async Task<Result<Guid>> Handle(CreateBookRequest request, CancellationToken cancellationToken)
    {
        var item = new Book(request.NameBook, request.CodeBook, request.Description, request.AuthorId, request.Price , request.CategoryId, request.Image);
        await _repository.AddAsync(item, cancellationToken);
        return Result<Guid>.Success(item.Id);
    }
}
