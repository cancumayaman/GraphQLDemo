using GraphQLSample.Models;
using GraphQLSample.Repositories;

namespace GraphQLSample.GraphQL.Query
{
    public class ProductQueries
    {
        public async Task<List<Product>> GetProductsAsync([Service] IProductService productService)
        {
            return await productService.GetProductsAsync();
        }

        public async Task<Product> GetProductAsync([Service] IProductService productService, Guid productId)
        {
            return await productService.GetProductByIdAsync(productId);
        }
    }
}
