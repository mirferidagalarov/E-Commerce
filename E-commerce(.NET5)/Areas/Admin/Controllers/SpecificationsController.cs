using e_commerce_.net5.Models.DataContext;
using E_commerce_.NET5_.AppCode.Application.SpecificationModule;
using E_commerce_.NET5_.Models.Entities;
using E_commerce_.NET5_.Models.ViewModels;
using MediatR;
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

        // GET: Admin/ Specifications
        public async Task<IActionResult> Index(SpecificationPagedQuery query)
        {
            var response = await _mediator.Send(query);
           
            return View(response);
        }

        // GET: Admin/ Specifications/Details/5
        public async Task<IActionResult> Details(SpecificationSingleQuery query)
        {

            Specification  Specification= await _mediator.Send(query);
            if ( Specification == null)
            {
                return NotFound();
            }

            return View( Specification);
        }

        // GET: Admin/ Specifications/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/ Specifications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SpecificationCreateCommand request)
        {
            int id=await _mediator.Send(request);

            if (id>0)
            { 
                return RedirectToAction(nameof(Index));
            }
            return View(request);
        }

        // GET: Admin/ Specifications/Edit/5
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

        // POST: Admin/ Specifications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit( SpecificationEditCommand request)
        {
            int id=await _mediator.Send(request);

            if (id>0)            
                return RedirectToAction(nameof(Index));
            
            return View(request);
        }

         [HttpPost]
        public async Task<IActionResult> Delete( SpecificationRemoveCommand request)
        {
           
            var response= await _mediator.Send(request);
            return Json(response);
            
        }

  
        
    }
}
