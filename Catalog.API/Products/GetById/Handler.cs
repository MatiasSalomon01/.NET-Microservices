
using Catalog.API.Exceptions;

namespace Catalog.API.Products.GetById;

public record GetProductByIdQuery(Guid Id) : IQuery<GetProductByIdResult>;

public record GetProductByIdResult(Product Product);


internal class GetProductByIdQueryHandler(IDocumentSession session, ILogger<GetProductByIdQueryHandler> logger) : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
{
    public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation("GetProductByIdQueryHandler.Hanlder called with {@GetProductByIdQuery}", query);

        var product = await session.LoadAsync<Product>(query.Id, cancellationToken) ?? throw new ProductNotFoundException();
        return new GetProductByIdResult(product);
    }
}
