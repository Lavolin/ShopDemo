using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ShopDemo.Core.Contracts;
using ShopDemo.Core.Data;
using ShopDemo.Core.Data.Models;
using ShopDemo.Core.Models;
using System.Text.Json.Nodes;

namespace ShopDemo.Core.Services
{
    /// <summary>
    /// Manage product data
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IConfiguration config;

        private readonly ApplicationDbContext context;
        /// <summary>
        /// IoC
        /// </summary>
        /// <param name="_config">Application configuration</param>
        public ProductService(IConfiguration _config, ApplicationDbContext _context)
        {
            config = _config;
            context = _context;
        }


        /// <summary>
        /// Get's all products
        /// </summary>
        /// <returns>List of products</returns>
        public async Task<IEnumerable<ProductDto>> GelAll()
        {
            //string dataPath = config.GetSection("DataFiles:Products").Value;
            //string data = await File.ReadAllTextAsync(dataPath);

            return await context
                .Products
                .AsNoTracking()
                .Where(p => p.IsActive)
                .Select(p => new ProductDto()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity
                }).ToArrayAsync();
                

          // string dataPath = config.GetValue
        }

        /// <summary>
        /// Add new product
        /// </summary>
        /// <param name="productDto">Product model</param>
        /// <returns></returns>
        public async Task Add(ProductDto productDto)
        {
            var product = new Product()
            {
                Name = productDto.Name,
                Price = productDto.Price,
                Quantity = productDto.Quantity
            };

            await context.AddAsync(product);
            await context.SaveChangesAsync();

            //await repo.AddAsync(product); // with Repository pattern
            //await repo.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var product = await context
                 .Products
                 .FirstOrDefaultAsync(p => p.Id == id);

            if (product != null)
            {
                product.IsActive = false;

                await context.SaveChangesAsync();
            }
        }
    }
}
