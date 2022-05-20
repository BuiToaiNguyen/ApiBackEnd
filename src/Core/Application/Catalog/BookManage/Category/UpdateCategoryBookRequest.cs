namespace TD.CitizenAPI.Application.Catalog.BookManage;

public class UpdateCategoryBookRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
    public string NameCate { get; set; } = default!;
    public string? Code { get; set; }

    public string? Description { get; set; }
    public string? Image { get; set; }

}

public class UpdateCategoryBookRequestValidator : CustomValidator<UpdateCategoryBookRequest>
{
    public UpdateCategoryBookRequestValidator(IRepository<CategoryBook> repository, IStringLocalizer<UpdateCategoryBookRequestValidator> localizer) =>
        RuleFor(p => p.NameCate)
            .NotEmpty();
}

public class UpdateCategoryBookRequestHandler : IRequestHandler<UpdateCategoryBookRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<CategoryBook> _repository;
    private readonly IStringLocalizer<UpdateCategoryBookRequestHandler> _localizer;

    public UpdateCategoryBookRequestHandler(IRepositoryWithEvents<CategoryBook> repository, IStringLocalizer<UpdateCategoryBookRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(UpdateCategoryBookRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(string.Format(_localizer["CategoryBook.notfound"], request.Id));

        item.Update(request.NameCate, request.Code, request.Description,request.Image);

        await _repository.UpdateAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}