using Microsoft.AspNetCore.Mvc;

namespace ShopDemo.Controllers
{
    /// <summary>
    /// Web shop products
    /// </summary>
    public class ProductController : Controller
    {
        /// <summary>
        /// List all products
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            
            return View();
        }
    }
}
