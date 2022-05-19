namespace TD.CitizenAPI.Application.Catalog.BookManage;

public partial class CreateCategoryBookRequest : IRequest<Result<Guid>>
{
    public string NameCate { get; set; } = default!;
    public string? Code { get; set; }

    public string? Description { get; set; }
    public string? Image { get; set; }

}

public class CreateCategoryBookRequestValidator : CustomValidator<CreateCategoryBookRequest>
{
    public CreateCategoryBookRequestValidator(IReadRepository<CategoryBook> repository, IStringLocalizer<CreateCategoryBookRequestValidator> localizer) =>
        RuleFor(p => p.NameCate).NotEmpty();
}

public class CreateCategoryBookRequestHandler : IRequestHandler<CreateCategoryBookRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<CategoryBook> _repository;

    public CreateCategoryBookRequestHandler(IRepositoryWithEvents<CategoryBook> repository) => _repository = repository;

    public async Task<Result<Guid>> Handle(CreateCategoryBookRequest request, CancellationToken cancellationToken)
    {
        var item = new CategoryBook(request.NameCate, request.Code, request.Description,request.Image);
        await _repository.AddAsync(item, cancellationToken);
        return Result<Guid>.Success(item.Id);
    }
}