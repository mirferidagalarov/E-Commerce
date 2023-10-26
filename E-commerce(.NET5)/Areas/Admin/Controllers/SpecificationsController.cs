using e_commerce_.net5.Models.DataContext;
using E_commerce_.NET5_.AppCode.Application.SpecificationModule;
using E_commerce_.NET5_.Models.Entities;
using E_commerce_.NET5_.Models.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce_.NET5_.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SpecificationsController : Controller
    {
        private readonly Dbcontext _context;
        private readonly IMediator _mediator;
        public SpecificationsController(Dbcontext context, IMediator mediator)
        {
            _mediator = mediator;
            _context = context;
        }

        [Authorize(Policy = "admin.specification.index")]
        public async Task<IActionResult> Index(SpecificationPagedQuery query)
        {
            var response = await _mediator.Send(query);

            return View(response);
        }

        [Authorize(Policy = "admin.specification.details")]
        public async Task<IActionResult> Details(SpecificationSingleQuery query)
        {

            Specification  Specification= await _mediator.Send(query);
            if ( Specification == null)
            {
                return NotFound();
            }

            return View( Specification);
        }

        [Authorize(Policy = "admin.specification.create")]
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "admin.specification.create")]
        public async Task<IActionResult> Create(SpecificationCreateCommand request)
        {
            int id=await _mediator.Send(request);

            if (id>0)
            { 
                return RedirectToAction(nameof(Index));
            }
            return View(request);
        }

        [Authorize(Policy = "admin.specification.edit")]
        public async Task<IActionResult> Edit(SpecificationSingleQuery query)
        {

             Specification  Specification = await _mediator.Send(query);
            if ( Specification == null)
            {
                return NotFound();
            }
            SpecificationViewModel vm = new SpecificationViewModel();
            vm.Id =  Specification.Id;
            vm.Name =  Specification.Name;
           


            return View(vm);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "admin.specification.edit")]
        public async Task<IActionResult> Edit( SpecificationEditCommand request)
        {
            int id=await _mediator.Send(request);

            if (id>0)            
                return RedirectToAction(nameof(Index));
            
            return View(request);
        }
       
        [HttpPost]
        [Authorize(Policy = "admin.specification.delete")]
        public async Task<IActionResult> Delete( SpecificationRemoveCommand request)
        {
           
            var response= await _mediator.Send(request);
            return Json(response);
            
        }

  
        
    }
}
