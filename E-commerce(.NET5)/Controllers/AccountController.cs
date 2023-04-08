using Microsoft.AspNetCore.Mvc;

namespace e_commerce_.net5.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Profile()
        {
            return View();
        }
        public IActionResult WishList()
        {
            return View();
        }
    }
}
