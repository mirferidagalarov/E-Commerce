using e_commerce_.net5.Models.DataContext;
using E_commerce_.NET5_.AppCode.Application.BrandModule;
using E_commerce_.NET5_.Models.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce_.NET5_.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class  BrandsController : Controller
    {
        private readonly Dbcontext _context;
        private readonly IMediator _mediator;
        public  BrandsController(Dbcontext context, IMediator mediator)
        {
            _mediator = mediator;
            _context = context;
        }


        [Authorize(Policy="admin.brands.index")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Brands.Where(m=>m.DeletedByUserId==null).ToListAsync());
        }

        [Authorize(Policy = "admin.brands.details")]
        public async Task<IActionResult> Details(BrandSingleQuery query)
        {

            Brand  Brand= await _mediator.Send(query);
            if ( Brand == null)
            {
                return NotFound();
            }

            return View( Brand);
        }

        [Authorize(Policy = "admin.brands.create")]
        public IActionResult Create()
        {
            return View();
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "admin.brands.create")]
        public async Task<IActionResult> Create(BrandCreateCommand request)
        {
            int id=await _mediator.Send(request);

            if (id>0)
            { 
                return RedirectToAction(nameof(Index));
            }
            return View(request);
        }

        [Authorize(Policy = "admin.brands.edit")]
        public async Task<IActionResult> Edit(BrandSingleQuery query)
        {

             Brand  Brand = await _mediator.Send(query);
            if ( Brand == null)
            {
                return NotFound();
            }
            BrandViewModel vm = new BrandViewModel();
            vm.Id =  Brand.Id;
            vm.Name =  Brand.Name;
            vm.Description =  Brand.Description;


            return View(vm);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "admin.brands.edit")]
        public async Task<IActionResult> Edit( BrandEditCommand request)
        {
            int id=await _mediator.Send(request);

            if (id>0)            
                return RedirectToAction(nameof(Index));
            
            return View(request);
        }

       
        [HttpPost]
        [Authorize(Policy = "admin.brands.delete")]
        public async Task<IActionResult> Delete(BrandRemoveCommand request)
        {
           
            var response= await _mediator.Send(request);
            return Json(response);
            
        }

  
        
    }
}
