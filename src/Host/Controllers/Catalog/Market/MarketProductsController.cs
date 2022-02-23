﻿using TD.CitizenAPI.Application.Catalog.MarketProducts;

namespace TD.CitizenAPI.Host.Controllers.Catalog;

public class MarketProductsController : VersionedApiController
{
    [HttpPost("search")]
    //[MustHavePermission(FSHAction.Search, FSHResource.Brands)]
    [OpenApiOperation("Search categories using available filters.", "")]
    public Task<PaginationResponse<MarketProductDto>> SearchAsync(SearchMarketProductsRequest request)
    {
        return Mediator.Send(request);
    }


    [HttpGet("{id:guid}")]
    //[MustHavePermission(FSHAction.View, FSHResource.Brands)]
    [OpenApiOperation("Get category details.", "")]
    public Task<Result<MarketProductDetailsDto>> GetAsync(Guid id)
    {
        return Mediator.Send(new GetMarketProductRequest(id));
    }

    [HttpPost]
    //[MustHavePermission(FSHAction.Create, FSHResource.Brands)]
    [OpenApiOperation("Create a new category.", "")]
    public Task<Result<Guid>> CreateAsync(CreateMarketProductRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    //[MustHavePermission(FSHAction.Update, FSHResource.Brands)]
    [OpenApiOperation("Update a category.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateMarketProductRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    //[MustHavePermission(FSHAction.Delete, FSHResource.Brands)]
    [OpenApiOperation("Delete a category.", "")]
    public Task<Result<Guid>> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteMarketProductRequest(id));
    }

    [HttpPost("fetchdata")]
    //[MustHavePermission(FSHAction.Generate, FSHResource.Brands)]
    [OpenApiOperation("Generate a number of random brands.", "")]
    public Task<string> FetchMarketProductAsync(FetchMarketProductRequest request)
    {
        return Mediator.Send(request);
    }
}