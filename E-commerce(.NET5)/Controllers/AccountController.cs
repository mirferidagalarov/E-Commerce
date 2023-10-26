using E_commerce_.NET5_.AppCode.Extensions;
using E_commerce_.NET5_.Models.Entities.Membership;
using E_commerce_.NET5_.Models.FormModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using XAct.Users;

namespace e_commerce_.net5.Controllers
{
    public class AccountController : Controller
    {
        readonly SignInManager<RiodeUser> _signInManager;
        readonly UserManager<RiodeUser> _userManager;
        readonly IConfiguration _configuration;
        public AccountController(SignInManager<RiodeUser> signInManager, UserManager<RiodeUser> userManager, IConfiguration configuration)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [Route("/signin.html")]
        public IActionResult SignIn()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("/signin.html")]
        public async Task<IActionResult> SignIn(LoginFormModel user)
        {
            if (ModelState.IsValid)
            {
                RiodeUser foundedUser = null;
                if (user.UserName.IsEmail())
                {
                    foundedUser = await _userManager.FindByEmailAsync(user.UserName);
                }
                else
                {
                    foundedUser = await _userManager.FindByNameAsync(user.UserName);
                }
                if (foundedUser == null)
                {
                    ViewBag.Message = "Istifadəçi adınız və ya şifrəniz yanlışdır";
                    goto end;
                }
                var signinResult = await _signInManager.PasswordSignInAsync(foundedUser, user.Password, true, true);
                if (!signinResult.Succeeded)
                {
                    ViewBag.Message = "İstifadəçi adınız və ya şifrəniz yanlışdır";
                    goto end;
                }
                var callbackUrl = Request.Query["ReturnUrl"];
                if (!string.IsNullOrWhiteSpace(callbackUrl))
                {
                    return Redirect(callbackUrl);
                }

                return RedirectToAction("Index", "Shop");
            }
            end:
            return View(user);
        }

        [AllowAnonymous]
        [Route("/register.html")]
        public IActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("/register.html")]
        public async Task<IActionResult> Register(RegisterFormModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new RiodeUser();
                user.Email = model.Email;
                user.UserName = model.Email;
                user.Name= model.Name;
                user.Surname = model.Surname;
                //user.EmailConfirmed = true;
                var result= await _userManager.CreateAsync(user,model.Password);

                if (result.Succeeded)
                {
                    var token=await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    string path = $"{Request.Scheme}://{Request.Host}/registration-confirm.html?email={user.Email}&token={token}";
                   var emailResponse= _configuration.SendEmail(user.Email, "Registration", $"Zəhmət olmasa <a href={path}>link</a> vasitəsilə qeydiyyatı tamamlayasınız");

                    if (emailResponse)
                    {
                        ViewBag.Message = "Təbriklər qeydiyyat tamamlandı";
                    }
                    else
                    {
                        ViewBag.Message = "E-mailə göndərərkən səhv aşkar edilmişdir yenidən cəhd edin";
                    }
                   
                    return RedirectToAction(nameof(SignIn));
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }

            }
            return View(model);
        }
        [AllowAnonymous]
        [Route("/registration-confirm.html")]
        public async Task<IActionResult> RegisterConfirm(string email,string token)
        {
            var  foundedUser = await _userManager.FindByEmailAsync(email);
            if (foundedUser==null)
            {
                ViewBag.Message = "Xetali token";
                goto end;
            }
            token = token.Replace(" ", "+");
            var result = await _userManager.ConfirmEmailAsync(foundedUser,token);
            if (!result.Succeeded)
            {
                ViewBag.Message = "Xetali token";
                goto end;
            }
            ViewBag.Message = "Hesab tesdiqlendi";
            end:
            return RedirectToAction(nameof(SignIn));
        }
        public IActionResult WishList()
        {
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }

        [Route("/logout.html")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
      
        }
    }
}
