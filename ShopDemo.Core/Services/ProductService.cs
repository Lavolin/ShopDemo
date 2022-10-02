using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShopDemo.Core.Contracts;
using ShopDemo.Core.Data.Common;
using ShopDemo.Core.Data.Models;
using ShopDemo.Core.Models;

namespace ShopDemo.Core.Services
{
    /// <summary>
    /// Manage product data
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IConfiguration config;

        private readonly IRepository repo;
        /// <summary>
        /// IoC
        /// </summary>
        /// <param name="_config">Application configuration</param>
        public ProductService(IConfiguration _config, IRepository _repo)
        {
            config = _config;
            repo = _repo;
        }


        /// <summary>
        /// Get's all products
        /// </summary>
        /// <returns>List of products</returns>
        public async Task<IEnumerable<ProductDto>> GelAll()
        {
            //string dataPath = config.GetSection("DataFiles:Products").Value;
            //string data = await File.ReadAllTextAsync(dataPath);

            return await repo.AllReadonly<Product>()
                .Where(p => p.IsActive)
                .Select(p => new ProductDto()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity
                }).ToArrayAsync();
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

            await repo.AddAsync(product);
            await repo.SaveChangesAsync();

        }

        public async Task Delete(Guid id)
        {
            var product = await repo.AllReadonly<Product>()
                 .FirstOrDefaultAsync(p => p.Id == id);

            if (product != null)
            {
                product.IsActive = false;

                await repo.SaveChangesAsync();
            }
        }
    }
}
