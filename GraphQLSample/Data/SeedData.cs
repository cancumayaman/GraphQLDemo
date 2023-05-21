using GraphQLSample.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLSample.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Products.Any())
                {
                    return;
                }
                context.Products.AddRange(

                    new Product
                    {
                        Id = Guid.NewGuid(),
                        ProductName = "Iphone",
                        ProductDescription = "Iphone 14",
                        ProductPrice = 35000,
                        ProductStock = 100
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        ProductName = "TV",
                        ProductDescription = "Smart TV",
                        ProductPrice = 20000,
                        ProductStock = 150
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
