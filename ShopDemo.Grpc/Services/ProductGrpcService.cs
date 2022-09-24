using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using ShopDemo.Core.Contracts;

namespace ShopDemo.Grpc.Services
{    
    public class ProductGrpcService : Product.ProductBase
    {
        private readonly IProductService productService;

        public ProductGrpcService(IProductService _productService)
        {
            productService = _productService;
        }
        public override async Task<ProductList> GetAll(Empty request, ServerCallContext context)
        {
            ProductList result = new ProductList();
            var products = await productService.GelAll();

            result.Item.AddRange(products.Select(p => new ProductItem()
            {
                Name = p.Name,
                Id = p.Id.ToString(),
                Price = (double)p.Price,
                Quantity = p.Quantity
            }));

            return result;
        }
    }
}
