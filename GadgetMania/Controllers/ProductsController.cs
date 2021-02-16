using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GadgetMania.Data;
using GadgetMania.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace GadgetMania.Controllers
{
    [Authorize(Roles = "admin")]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public ProductsController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _environment = env;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.GadgetManiaProducts.Include(p => p.Categories).Include(p=>p.Suppliers);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.GadgetManiaProducts
                .Include(p => p.Categories)
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["CategoryID"] = new SelectList(_context.GadgetManiaCategories, "CategoryID", "CategoryName");
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "SupplierName");

            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductID,ProductName,Price,ProductDescription,File,CategoryID,SupplierID")] Products products)
        {
            using (var memoryStream = new MemoryStream())
            {
                await products.File.FormFile.CopyToAsync(memoryStream);

                string photoname = products.File.FormFile.FileName;
                products.Extension = Path.GetExtension(photoname);
                if (!".jpg.jpeg.png.gif.bmp".Contains(products.Extension.ToLower()))
                {
                    ModelState.AddModelError("File.FormFile", "Invalid Format of Image Given.");
                }
                else
                {
                    ModelState.Remove("Extension");
                }
            }
            if (ModelState.IsValid)
            {
                _context.Add(products);
                await _context.SaveChangesAsync();
                var uploadsRootFolder = Path.Combine(_environment.WebRootPath, "product_images");
                if (!Directory.Exists(uploadsRootFolder))
                {
                    Directory.CreateDirectory(uploadsRootFolder);
                }
                string filename = products.ProductID + products.Extension;
                var filePath = Path.Combine(uploadsRootFolder, filename);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await products.File.FormFile.CopyToAsync(fileStream).ConfigureAwait(false);
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryID"] = new SelectList(_context.GadgetManiaCategories, "CategoryID", "CategoryName", products.CategoryID);
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "SupplierName");
            return View(products);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.GadgetManiaProducts.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }
            ViewData["CategoryID"] = new SelectList(_context.GadgetManiaCategories, "CategoryID", "CategoryName", products.CategoryID);
            return View(products);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductID,ProductName,Price,ProductDescription,Extension,CategoryID,SupplierID")] Products products)
        {
            if (id != products.ProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(products);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductsExists(products.ProductID))
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
            ViewData["CategoryID"] = new SelectList(_context.GadgetManiaCategories, "CategoryID", "CategoryName", products.CategoryID);
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "SupplierName");

            return View(products);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.GadgetManiaProducts
                .Include(p => p.Categories)
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var products = await _context.GadgetManiaProducts.FindAsync(id);
            _context.GadgetManiaProducts.Remove(products);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductsExists(int id)
        {
            return _context.GadgetManiaProducts.Any(e => e.ProductID == id);
        }
    }
}
