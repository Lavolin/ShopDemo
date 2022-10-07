using Microsoft.AspNetCore.Mvc;
using ShopDemo.Models;
using System.Diagnostics;

namespace ShopDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //if (TempData.ContainsKey("LastAccessTime"))
            //{
            //    return Ok(TempData["LastAccessTime"]);
            //}

            //TempData["LastAccessTime"] = DateTime.Now;

            //this.HttpContext.Response.Cookies.Append("ToshkoCookie", "Todor");

            this.HttpContext.Session.SetString("name", "Toshko");

            return View();
        }

        public IActionResult Privacy()
        {
           string? name = this.HttpContext.Session.GetString("name");

            if (!string.IsNullOrEmpty(name))
            {
                return Ok(name);
            }
            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}