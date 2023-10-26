using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce_.NET5_.Controllers
{
    public class BlogController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Details()
        {
            return View();
        }
        public IActionResult Comment(int postId,string comment)
        {

            return View();
        }
    }
}
