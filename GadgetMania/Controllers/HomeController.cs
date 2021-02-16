using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GadgetMania.Models;

using Microsoft.EntityFrameworkCore;
using GadgetMania.Data;
using Microsoft.AspNetCore.Authorization;

namespace GSMArena_Final.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.GadgetManiaCategories.OrderBy(x => Guid.NewGuid()).ToListAsync());
        }
        public async Task<IActionResult> ViewProductByCategory(int? id)
        {
            var applicationDbContext = _context.GadgetManiaProducts
            .Include(b => b.Categories).Where(m => m.CategoryID== id);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> ViewAllProducts()
        {
            var applicationDbContext = _context.GadgetManiaProducts.Include(p => p.Categories).Include(p => p.Suppliers);
            return View(await applicationDbContext.ToListAsync());
        }

        [Authorize]
        public async Task<IActionResult> ViewSupplire(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mobile = await _context.Suppliers
                .Include(b => b.SuppliersProducts)
                .FirstOrDefaultAsync(m => m.SupplierID== id);
            if (mobile == null)
            {
                return NotFound();
            }

            return View(mobile);
        }
        public async Task<IActionResult> ViewRecipeID(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mobile = await _context.GadgetManiaProducts
                .Include(b => b.Categories)
                .FirstOrDefaultAsync(m => m.CategoryID== id);
            if (mobile == null)
            {
                return NotFound();
            }

            return View(mobile);
        }
        public async Task<IActionResult> ViewReviews(int? id)
        {
            var applicationDbContext = _context.GadgetManiaSupplierReview
            .Include(b => b.Products).Where(m => m.Products.ProductID == id);
            return View(await applicationDbContext.ToListAsync());
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
