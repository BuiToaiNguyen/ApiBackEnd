using TD.CitizenAPI.Application.Catalog.BookManage;

namespace TD.CitizenAPI.Host.Controllers.Catalog;

public class ManageBookController : VersionedApiController
{
    [HttpPost("search")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.Search, FSHResource.Brands)]
    [OpenApiOperation("lấy danh danh sách  sách", "")]
    public Task<PaginationResponse<BookDto>> SearchAsync(SearchBookRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.View, FSHResource.Brands)]
    [OpenApiOperation("chi tiết 1  Sách.", "")]
    public Task<Result<BookDetailsDto>> GetAsync(Guid id)
    {
        return Mediator.Send(new GetBookRequest(id));
    }

    [HttpPost]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.Create, FSHResource.Brands)]
    [OpenApiOperation("Tạo mới Sách .", "")]
    public Task<Result<Guid>> CreateAsync(CreateBookRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [AllowAnonymous]
    [TenantIdHeader]

    //[MustHavePermission(FSHAction.Update, FSHResource.Brands)]
    [OpenApiOperation("Cập nhật Sách.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateBookRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [AllowAnonymous]
    [TenantIdHeader]
    [OpenApiOperation("Xóa sách.", "")]
    public Task<Result<Guid>> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteBookRequest(id));
    }


}