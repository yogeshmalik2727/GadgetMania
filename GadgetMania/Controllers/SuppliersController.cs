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
    public class SuppliersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SuppliersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Suppliers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Suppliers.ToListAsync());
        }

        // GET: Suppliers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suppliers = await _context.Suppliers
                .FirstOrDefaultAsync(m => m.SupplierID == id);
            if (suppliers == null)
            {
                return NotFound();
            }

            return View(suppliers);
        }

        // GET: Suppliers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Suppliers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SupplierID,SupplierName,SupplierAddress,SupplierContact,ContactPerson")] Suppliers suppliers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(suppliers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(suppliers);
        }

        // GET: Suppliers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suppliers = await _context.Suppliers.FindAsync(id);
            if (suppliers == null)
            {
                return NotFound();
            }
            return View(suppliers);
        }

        // POST: Suppliers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SupplierID,SupplierName,SupplierAddress,SupplierContact,ContactPerson")] Suppliers suppliers)
        {
            if (id != suppliers.SupplierID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(suppliers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuppliersExists(suppliers.SupplierID))
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
            return View(suppliers);
        }

        // GET: Suppliers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suppliers = await _context.Suppliers
                .FirstOrDefaultAsync(m => m.SupplierID == id);
            if (suppliers == null)
            {
                return NotFound();
            }

            return View(suppliers);
        }

        // POST: Suppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var suppliers = await _context.Suppliers.FindAsync(id);
            _context.Suppliers.Remove(suppliers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuppliersExists(int id)
        {
            return _context.Suppliers.Any(e => e.SupplierID == id);
        }
    }
}
