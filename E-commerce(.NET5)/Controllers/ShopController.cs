using e_commerce_.net5.Models.DataContext;
using E_commerce_.NET5_.Models.Entities;
using E_commerce_.NET5_.Models.FormModels;
using E_commerce_.NET5_.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace e_commerce_.net5.Controllers
{
    public class ShopController : Controller
    {
        readonly Dbcontext _dbcontext;
        public ShopController(Dbcontext dbcontext)
        {
           _dbcontext = dbcontext;
        }
        //[AllowAnonymous]
        public IActionResult Index()
        {
            ShopFilterViewModel vm=new ShopFilterViewModel();
         
            vm.Brands = _dbcontext.Brands.Where(b=>b.DeletedByUserId==null).ToList();
            vm.ProductColors=_dbcontext.ProductColors.Where(b=>b.DeletedByUserId==null).ToList();
            vm.ProductSizes = _dbcontext.ProductSizes.Where(b => b.DeletedByUserId == null).ToList();
            vm.Categories = _dbcontext.Categories.Include(c=>c.Children).Where(b => b.DeletedByUserId == null&& b.ParentId==null).ToList();
            vm.Products = _dbcontext.Products.Include(p => p.Images.Where(i => i.IsMain == true)).Include(c=>c.Brand).Where(b=>b.DeletedByUserId == null).ToList();

            return View(vm);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Filter(ShopFilterFormModel model)
        {
            var query = _dbcontext.Products
                .Include(p => p.Images.Where(i => i.IsMain == true))
                .Include(c => c.Brand)
                .Include(c => c.ProductSizeColorCollection)
                .Where(b => b.DeletedByUserId == null)
                .AsQueryable();

            if (model?.Brands?.Count()>0)
            {
                query = query.Where(p => model.Brands.Contains(p.BrandId));
            }
            if (model?.Size?.Count() > 0)
            {
                query = query.Where(p => p.ProductSizeColorCollection.Any(pscc=>model.Size.Contains(pscc.SizeId)));
            }
            if (model?.Colors?.Count() > 0)
            {
                query = query.Where(p => p.ProductSizeColorCollection.Any(pscc => model.Colors.Contains(pscc.ColorId)));
            }
            return PartialView("_ProductContainer",query.ToList());

            //return Json(new
            //{
            //    error = false,
            //    data = query.ToList()
            //}) ;
        }
        [AllowAnonymous] 
        public IActionResult Details(int id)
        {
       
            var product = _dbcontext.Products
                          .Include(p=>p.Images)
                          .Include(p=>p.SpecificationValues.Where(s=>s.DeletedByUserId==null))
                          .ThenInclude(s=>s.Specification)
                          .FirstOrDefault(p => p.Id == id && p.DeletedByUserId==null);

            if (product==null)
            {
                return NotFound();

            }
            return View(product);
        }
    }
}
