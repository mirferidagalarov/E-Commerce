using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using E_commerce_.NET5_.Models.Entities;
using e_commerce_.net5.Models.DataContext;
using MediatR;
using E_commerce_.NET5_.AppCode.Application.BrandModule;

namespace E_commerce_.NET5_.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandsController : Controller
    {
        private readonly Dbcontext _context;
        private readonly IMediator _mediator;
        public BrandsController(Dbcontext context, IMediator mediator)
        {
            _mediator = mediator;
            _context = context;
        }

        // GET: Admin/Brands
        public async Task<IActionResult> Index()
        {
            return View(await _context.Brands.Where(m=>m.DeletedByUserId==null).ToListAsync());
        }

        // GET: Admin/Brands/Details/5
        public async Task<IActionResult> Details(BrandSingleQuery query)
        {

           Brand brand= await _mediator.Send(query);
            if (brand == null)
            {
                return NotFound();
            }

            return View(brand);
        }

        // GET: Admin/Brands/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Brands/Create
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

        // GET: Admin/Brands/Edit/5
        public async Task<IActionResult> Edit(BrandSingleQuery query)
        {

            Brand brand = await _mediator.Send(query);
            if (brand == null)
            {
                return NotFound();
            }
            BrandViewModel vm = new BrandViewModel();
            vm.Id = brand.Id;
            vm.Name = brand.Name;
            vm.Description = brand.Description;


            return View(vm);
        }

        // POST: Admin/Brands/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BrandEditCommand request)
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
