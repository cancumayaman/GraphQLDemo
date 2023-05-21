using GraphQLSample.Data;
using GraphQLSample.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLSample.Repositories
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }
        public async Task<Product> GetProductByIdAsync(Guid productId)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == productId) ?? new Product();
        }
        public async Task<bool> AddProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
        public async Task<bool> UpdateProductAsync(Product product)
        {
            var exists = _context.Products.Any(p => p.Id == product.Id);
            if (exists)
            {
                _context.Products.Update(product);
                var result = await _context.SaveChangesAsync();
                return result > 0;
            }
            return false;
        }
        public async Task<bool> DeleteProductAsync(Guid productId)
        {
            var product = _context.Products.Find(productId);
            if (product is not null)
            {
                _context.Products.Remove(product);
                var result = await _context.SaveChangesAsync();
                return result > 0;
            }
            return false;
        }
    }
}
