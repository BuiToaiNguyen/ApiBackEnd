using TD.CitizenAPI.Application.Catalog.BookManage;

namespace TD.CitizenAPI.Host.Controllers.Catalog;

public class ManageAuthorBookController : VersionedApiController
{
    [HttpPost("search")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.Search, FSHResource.Brands)]
    [OpenApiOperation("lấy danh sách danh tác giả", "")]
    public Task<PaginationResponse<AuthorBookDto>> SearchAsync(SearchAuthorBooksRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.View, FSHResource.Brands)]
    [OpenApiOperation("chi tiết 1 tác giả.", "")]
    public Task<Result<AuthorBookDetailsDto>> GetAsync(Guid id)
    {
        return Mediator.Send(new GetAuthorBookRequest(id));
    }

    [HttpPost]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.Create, FSHResource.Brands)]
    [OpenApiOperation("Tạo tác giả .", "")]
    public Task<Result<Guid>> CreateAsync(CreateAuthorBookRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [AllowAnonymous]
    [TenantIdHeader]

    //[MustHavePermission(FSHAction.Update, FSHResource.Brands)]
    [OpenApiOperation("Cập nhậttác giả.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateAuthorBookRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [AllowAnonymous]
    [TenantIdHeader]
    [OpenApiOperation("Xóa tác giả.", "")]
    public Task<Result<Guid>> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteAuthorBookRequest(id));
    }


}