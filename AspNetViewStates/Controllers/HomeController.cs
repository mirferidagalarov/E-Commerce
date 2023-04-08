using AspNetViewStates.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetViewStates.Controllers
{
    public class HomeController : Controller
    {
        /*
       ViewBag
       ViewData
       TempData
       */

        public IActionResult Index()
        {
            DictionaryItem di = new DictionaryItem();
            di.WordAze = "Qarpız";
            di.WordEng = "WaterMelon";
            List<DictionaryItem> list = new List<DictionaryItem>();
            list.Add(di);
            list.Add(new DictionaryItem
            {
                WordAze = "siyahı",
                WordEng="List"
            }) ;

            int len = list.Count();
            //if (len == 0)
            //{
            //    ViewBag.Message = "Məlumat Yoxdur";
            //}
            //else if( len % 2==0)
            //{
            //    ViewBag.Message = "Cüt sayda məlumat var";

            //}
            //else
            //{
            //    ViewBag.Message = "Tək sayda məlumat var";
            //}
            if (len == 0)
            {
                ViewData["Message"] = "Məlumat Yoxdur";
            }
            else if (len % 2 == 0)
            {
                ViewData["Message"] = "Cüt sayda məlumat var";

            }
            else
            {
                ViewData["Message"] = "Tək sayda məlumat var";
            }


            return View();
        }

      



      
    }
}
