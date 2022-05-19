using TD.CitizenAPI.Application.Catalog.BookManage;

namespace TD.CitizenAPI.Host.Controllers.Catalog;

public class AuthorBookController : VersionedApiController
{
    //[HttpPost("search")]
    //[AllowAnonymous]
    //[TenantIdHeader]
    ////[MustHavePermission(FSHAction.Search, FSHResource.Brands)]
    //[OpenApiOperation("lấy danh sách danh mục sách", "")]
    //public Task<PaginationResponse<CategoryBookDto>> SearchAsync(SearchCategoryBooksRequest request)
    //{
    //    return Mediator.Send(request);
    //}

    //[HttpGet("{id:guid}")]
    //[AllowAnonymous]
    //[TenantIdHeader]
    ////[MustHavePermission(FSHAction.View, FSHResource.Brands)]
    //[OpenApiOperation("chi tiết 1 danh mục Sách.", "")]
    //public Task<Result<CategoryBookDetailsDto>> GetAsync(Guid id)
    //{
    //    return Mediator.Send(new GetCategoryBookRequest(id));
    //}

    [HttpPost]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.Create, FSHResource.Brands)]
    [OpenApiOperation("Tạo tác giả .", "")]
    public Task<Result<Guid>> CreateAsync(CreateAuthorBookRequest request)
    {
        return Mediator.Send(request);
    }

    //[HttpPut("{id:guid}")]
    //[AllowAnonymous]
    //[TenantIdHeader]

    ////[MustHavePermission(FSHAction.Update, FSHResource.Brands)]
    //[OpenApiOperation("Cập nhật danh mục Sách.", "")]
    //public async Task<ActionResult<Guid>> UpdateAsync(UpdateCategoryBookRequest request, Guid id)
    //{
    //    return id != request.Id
    //        ? BadRequest()
    //        : Ok(await Mediator.Send(request));
    //}

    //[HttpDelete("{id:guid}")]
    //[AllowAnonymous]
    //[TenantIdHeader]
    //[OpenApiOperation("Xóa danh mục.", "")]
    //public Task<Result<Guid>> DeleteAsync(Guid id)
    //{
    //    return Mediator.Send(new DeleteCategoryBookRequest(id));
    //}


}