using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopDemo.Core.Constants;
using ShopDemo.Core.Contracts;
using ShopDemo.Core.Models;

namespace ShopDemo.Controllers
{
    /// <summary>
    /// Web shop products
    /// </summary>
    public class ProductController : BaseController
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
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var products = await productService.GelAll();
            ViewData["Title"] = "Products";

            return View(products);
        }

        [HttpGet]
        [Authorize(Roles = $"{RoleConstants.Manager}, {RoleConstants.Supervisor}")]
        public IActionResult Add()
        {
            var model = new ProductDto();
            ViewData["Title"] = "Add new Product";

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = $"{RoleConstants.Manager}, {RoleConstants.Supervisor}")]
        public async Task<IActionResult> Add(ProductDto model)
        {
            ViewData["Title"] = "Add new Product";
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await productService.Add(model);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Authorize(Policy = "CanDeleteProduct")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await productService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
