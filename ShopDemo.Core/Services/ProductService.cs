using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ShopDemo.Core.Contracts;
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
        /// <summary>
        /// IoC
        /// </summary>
        /// <param name="_config">Application configuration</param>
        public ProductService(IConfiguration _config)
        {
            config = _config;
        }

        /// <summary>
        /// Get's all products
        /// </summary>
        /// <returns>List of products</returns>
        public async Task<IEnumerable<ProductDto>> GelAll()
        {
            string data = await File.ReadAllTextAsync("Data/products.json");

            return JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(data);

          // string dataPath = config.GetValue
        }
    }
}
