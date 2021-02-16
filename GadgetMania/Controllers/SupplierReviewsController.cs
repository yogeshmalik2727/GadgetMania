using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GadgetMania.Data;
using GadgetMania.Models;
using Microsoft.AspNetCore.Authorization;

namespace GadgetMania.Controllers
{
    [Authorize(Roles = "admin")]
    public class SupplierReviewsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SupplierReviewsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SupplierReviews
        public async Task<IActionResult> Index()
        {
            return View(await _context.GadgetManiaSupplierReview.ToListAsync());
        }

        // GET: SupplierReviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplierReview = await _context.GadgetManiaSupplierReview
                .FirstOrDefaultAsync(m => m.ReviewID == id);
            if (supplierReview == null)
            {
                return NotFound();
            }

            return View(supplierReview);
        }

        // GET: SupplierReviews/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SupplierReviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReviewID,Name,Rating,ReviewText,SupplierID,ReviewDate")] SupplierReview supplierReview)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supplierReview);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(supplierReview);
        }

        // GET: SupplierReviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplierReview = await _context.GadgetManiaSupplierReview.FindAsync(id);
            if (supplierReview == null)
            {
                return NotFound();
            }
            return View(supplierReview);
        }

        // POST: SupplierReviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReviewID,Name,Rating,ReviewText,SupplierID,ReviewDate")] SupplierReview supplierReview)
        {
            if (id != supplierReview.ReviewID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supplierReview);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupplierReviewExists(supplierReview.ReviewID))
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
            return View(supplierReview);
        }

        // GET: SupplierReviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplierReview = await _context.GadgetManiaSupplierReview
                .FirstOrDefaultAsync(m => m.ReviewID == id);
            if (supplierReview == null)
            {
                return NotFound();
            }

            return View(supplierReview);
        }

        // POST: SupplierReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supplierReview = await _context.GadgetManiaSupplierReview.FindAsync(id);
            _context.GadgetManiaSupplierReview.Remove(supplierReview);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupplierReviewExists(int id)
        {
            return _context.GadgetManiaSupplierReview.Any(e => e.ReviewID == id);
        }
    }
}
