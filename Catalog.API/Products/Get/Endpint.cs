
using Catalog.API.Products.CreateProduct;

namespace Catalog.API.Products.List;

public record GetProductsResponse(IEnumerable<Product> Products);


public class GetProductsEndpint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products", async (ISender sender) =>
        {
            var result = await sender.Send(new GetProductsQuery());
            var response = result.Adapt<GetProductsResponse>();
            
            return Results.Ok(response);
        })
        .WithName("GetProducts")
        .Produces<CreateProductResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Products")
        .WithDescription("Get Product");
    }
}
