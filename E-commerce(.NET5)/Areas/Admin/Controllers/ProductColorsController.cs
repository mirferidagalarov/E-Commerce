using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using E_commerce_.NET5_.Models.Entities;
using e_commerce_.net5.Models.DataContext;

namespace E_commerce_.NET5_.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductColorsController : Controller
    {
        private readonly Dbcontext _context;

        public ProductColorsController(Dbcontext context)
        {
            _context = context;
        }

        // GET: Admin/ProductColors
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductColors.ToListAsync());
        }

        // GET: Admin/ProductColors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productColor = await _context.ProductColors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productColor == null)
            {
                return NotFound();
            }

            return View(productColor);
        }

        // GET: Admin/ProductColors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/ProductColors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HexCode,Name,Description,Id,CreatedByUserId,CreatedDate,DeletedByUserId,DeletedDate")] ProductColor productColor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productColor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productColor);
        }

        // GET: Admin/ProductColors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productColor = await _context.ProductColors.FindAsync(id);
            if (productColor == null)
            {
                return NotFound();
            }
            return View(productColor);
        }

        // POST: Admin/ProductColors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HexCode,Name,Description,Id,CreatedByUserId,CreatedDate,DeletedByUserId,DeletedDate")] ProductColor productColor)
        {
            if (id != productColor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productColor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductColorExists(productColor.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(productColor);
        }

        // GET: Admin/ProductColors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productColor = await _context.ProductColors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productColor == null)
            {
                return NotFound();
            }

            return View(productColor);
        }

        // POST: Admin/ProductColors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productColor = await _context.ProductColors.FindAsync(id);
            _context.ProductColors.Remove(productColor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductColorExists(int id)
        {
            return _context.ProductColors.Any(e => e.Id == id);
        }
    }
}
