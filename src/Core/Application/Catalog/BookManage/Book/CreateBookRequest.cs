//namespace TD.CitizenAPI.Application.Catalog.BookMange;

//public partial class CreateBookRequest : IRequest<Result<Guid>>
//{
//    public string Name { get; set; } = default!;
//    public string? Code { get; set; }

//    public string? Description { get; set; }
//}

//public class CreateBookRequestValidator : CustomValidator<CreateBookRequest>
//{
//    public CreateBookRequestValidator(IReadRepository<Book> repository, IStringLocalizer<CreateBookRequestValidator> localizer) =>
//        RuleFor(p => p.Name).NotEmpty();
//}

//public class CreateBookRequestHandler : IRequestHandler<CreateBookRequest, Result<Guid>>
//{
//    // Add Domain Events automatically by using IRepositoryWithEvents
//    private readonly IRepositoryWithEvents<Book> _repository;

//    public CreateBookRequestHandler(IRepositoryWithEvents<Book> repository) => _repository = repository;

//    public async Task<Result<Guid>> Handle(CreateBookRequest request, CancellationToken cancellationToken)
//    {
//        var item = new Book(request.Name, request.Code, request.Description,request);
//        await _repository.AddAsync(item, cancellationToken);
//        return Result<Guid>.Success(item.Id);
//    }
//}