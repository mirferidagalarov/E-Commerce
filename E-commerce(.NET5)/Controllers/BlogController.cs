using Microsoft.AspNetCore.Mvc;

namespace E_commerce_.NET5_.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details()
        {
            return View();
        }
    }
}
