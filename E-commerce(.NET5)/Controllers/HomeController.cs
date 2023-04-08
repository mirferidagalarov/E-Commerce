using e_commerce_.net5.Models;
using e_commerce_.net5.Models.DataContext;
using e_commerce_.net5.Models.Entities;
using E_commerce_.NET5_.AppCode.Extensions;
using E_commerce_.NET5_.Models.Entities;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace e_commerce_.net5.Controllers
{
    public class HomeController : Controller
    {
        private readonly Dbcontext _dbcontext;
        private readonly IConfiguration _configuration;
        public HomeController(Dbcontext dbcontext, IConfiguration configuration)
        {
            _dbcontext = dbcontext;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Contact()
        {
            ViewBag.CurrentDate = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss fffffff");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Contact(ContactPost model)
        {
            ViewBag.CurrentDate = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss fffffff");

            if (ModelState.IsValid)
            {
                _dbcontext.ContactPosts.Add(model);
                _dbcontext.SaveChanges();
                //ModelState.Clear();
                //ViewBag.Message = "Sizin müraciətiniz qeydə alındı.Tezliklə sizə geri dönəcəyik";
                // return View();
                return Json(new
                {
                    error = false,
                    message = "Sizin müraciətiniz qeydə alındı.Tezliklə sizə geri dönəcəyik"
                });
            }

            return Json(new
            {
                error = true,
                message = "Biraz sonra yenidən yoxlayın"
            });

            //  return View(model);
        }
        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult Faqs()
        {
            var faqs = _dbcontext.Faqs.Where(f => f.DeletedByUserId == null).ToList();
            return View(faqs);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Subscribe([Bind("Email")] Subscribe subscribe)
        {
            if (ModelState.IsValid)
            {
                var current = _dbcontext.Subscribes.FirstOrDefault(s => s.Email.Equals(subscribe.Email));

                if (current != null && current.EmailConfirmed == true)
                {
                    return Json(new
                    {
                        error = true,
                        message = "Bu e-poçta daha öncə abunəçi qeydiyyatı edilib"
                    });
                }
                else if (current != null && (current.EmailConfirmed ?? false == false))
                {
                    return Json(new
                    {
                        error = true,
                        message = "Bu e-poçta göndərilmiş linklə qeydiyyat tamamlanmayıb"
                    });
                }
                _dbcontext.Subscribes.Add(subscribe);
                _dbcontext.SaveChanges();

                string token = $"subscribetoken-{subscribe.Id}--{DateTime.Now:yyyyMMddHHmmss}";
                token = token.Encrypt();

                string path = $"{Request.Scheme}://{Request.Host}/subscribe-confirm?token={token}";
                var mailSened = _configuration.SendEmail(subscribe.Email, "Riode Newsletter subscribe",
                    $"Zəhmət olmasa <a href={path}>link</a> vasitəsilə abunəliyi tamamlayasınız");

                if (mailSened == false)
                {
                    _dbcontext.Database.RollbackTransaction();
                    return Json(new
                    {
                        error = false,
                        message = "Email göndərilən zaman xəta baş verdi.Biraz sonra yenidən yoxlayın"
                    });
                }
                return Json(new
                {
                    error = false,
                    message = "Sorğunuz uğurla qeydə alındı.Zəhmət olmasa E-poçtunuza göndərilmiş linkdən abunəliyi tamamlayasınız"
                });
            }


            return Json(new
            {
                error = true,
                message = "Sorğunun icrası zamanı xəta ayrandı.Biraz sonra yenidən yoxlayın"
            });

        }

        [HttpGet]
        [Route("subscribe-confirm")]
        public IActionResult SubscribeConfirm(string token)
        {
            token = token.Decrypt();
            Match match = Regex.Match(token, @"subscribetoken-(?<id>\d{2})--(?<executeTimeStamp>\d{14})");
            if (match.Success)
            {
                int id = Convert.ToInt32(match.Groups["id"].Value);
                string executeTimeStamp = match.Groups["executeTimeStamp"].Value;
                var subscribe = _dbcontext.Subscribes.FirstOrDefault(s => s.Id == id && s.DeletedByUserId == null);
                if (subscribe == null)
                {
                    ViewBag.Message = Tuple.Create(true, "Token xətası");
                    goto end;
                }
                if ((subscribe.EmailConfirmed ?? false) == true)
                {
                    ViewBag.Message = Tuple.Create(true, "Artıq təsdiq edilib!");
                    goto end;
                }
                subscribe.EmailConfirmed = true;
                subscribe.EmailConfirmedDate = DateTime.Now;
                _dbcontext.SaveChanges();

                ViewBag.Message = Tuple.Create(false, "Abunəliyiniz təsdiq edildi");
            }
            else
            {
                ViewBag.Message = Tuple.Create(true, "Token xətası");
                goto end;
            }
        end:
            return View();

        }

    }
}
