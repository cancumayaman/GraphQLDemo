using GraphQLSample.Models;

namespace GraphQLSample.Repositories
{
    public interface IProductService
    {
        public Task<List<Product>> GetProductsAsync();
        public Task<Product> GetProductByIdAsync(Guid productId);
        public Task<bool> AddProductAsync(Product product);
        public Task<bool> UpdateProductAsync(Product product);
        public Task<bool> DeleteProductAsync(Guid productId);
    }
}
