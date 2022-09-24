using Microsoft.AspNetCore.Mvc;
using ShopDemo.Core.Contracts;

namespace ShopDemo.Controllers
{
    /// <summary>
    /// Web shop products
    /// </summary>
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }


        /// <summary>
        /// List all products
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var products = await productService.GelAll();
            ViewData["Title"] = "Products";

            return View(products);
        }
    }
}
