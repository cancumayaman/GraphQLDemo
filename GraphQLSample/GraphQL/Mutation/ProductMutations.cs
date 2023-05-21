using GraphQLSample.Models;
using GraphQLSample.Repositories;
using HotChocolate.Subscriptions;

namespace GraphQLSample.GraphQL.Mutation
{
    public class ProductMutations
    {
        public async Task<bool> AddProductAsync([Service] IProductService productService, Product product, [Service] ITopicEventSender sender, CancellationToken cancellationToken)
        {            
            await sender.SendAsync(nameof(AddProductAsync), product, cancellationToken);
            return await productService.AddProductAsync(product);   
        }

        public async Task<bool> UpdateProductAsync([Service] IProductService productService, Product product)
        {
            return await productService.UpdateProductAsync(product);
        }

        public async Task<bool> DeleteProductAsync([Service] IProductService productService, Guid productId)
        {
            return await productService.DeleteProductAsync(productId);
        }
    }
}
