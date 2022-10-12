using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ShopDemo.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
       
    }
}
