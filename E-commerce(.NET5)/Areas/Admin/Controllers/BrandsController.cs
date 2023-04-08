using e_commerce_.net5.Models.DataContext;
using E_commerce_.NET5_.AppCode.Application.BrandModule;
using E_commerce_.NET5_.Models.Entities;
using MediatR;
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

        // GET: Admin/ Brand
        public async Task<IActionResult> Index()
        {
            return View(await _context.Brands.Where(m=>m.DeletedByUserId==null).ToListAsync());
        }

        // GET: Admin/ Brand/Details/5
        public async Task<IActionResult> Details(BrandSingleQuery query)
        {

            Brand  Brand= await _mediator.Send(query);
            if ( Brand == null)
            {
                return NotFound();
            }

            return View( Brand);
        }

        // GET: Admin/ Brand/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/ Brand/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BrandCreateCommand request)
        {
            int id=await _mediator.Send(request);

            if (id>0)
            { 
                return RedirectToAction(nameof(Index));
            }
            return View(request);
        }

        // GET: Admin/ Brand/Edit/5
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

        // POST: Admin/ Brand/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit( BrandEditCommand request)
        {
            int id=await _mediator.Send(request);

            if (id>0)            
                return RedirectToAction(nameof(Index));
            
            return View(request);
        }

         [HttpPost]
        public async Task<IActionResult> Delete(BrandRemoveCommand request)
        {
           
            var response= await _mediator.Send(request);
            return Json(response);
            
        }

  
        
    }
}
