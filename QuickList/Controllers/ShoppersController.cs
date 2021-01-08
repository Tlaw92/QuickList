
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuickList.Data;
using QuickList.Models;

namespace QuickList.Controllers
{
    public class ShoppersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShoppersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Shoppers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Shopper.Include(s => s.IdentityUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Shoppers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopper = await _context.Shopper
                .Include(s => s.IdentityUser)
                .FirstOrDefaultAsync(m => m.ShopperId == id);
            if (shopper == null)
            {
                return NotFound();
            }

            return View(shopper);
        }

        // GET: Shoppers/Create
        public IActionResult Create()
        {
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Shoppers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShopperId,FirstName,LastName,Address,ZipCode,Lattitude,Longitude,IdentityUserId")] Shopper shopper)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shopper);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", shopper.IdentityUserId);
            return View(shopper);
        }

        // GET: Shoppers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopper = await _context.Shopper.FindAsync(id);
            if (shopper == null)
            {
                return NotFound();
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", shopper.IdentityUserId);
            return View(shopper);
        }

        // POST: Shoppers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShopperId,FirstName,LastName,Address,ZipCode,Lattitude,Longitude,IdentityUserId")] Shopper shopper)
        {
            if (id != shopper.ShopperId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shopper);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShopperExists(shopper.ShopperId))
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
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", shopper.IdentityUserId);
            return View(shopper);
        }

        // GET: Shoppers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopper = await _context.Shopper
                .Include(s => s.IdentityUser)
                .FirstOrDefaultAsync(m => m.ShopperId == id);
            if (shopper == null)
            {
                return NotFound();
            }

            return View(shopper);
        }

        // POST: Shoppers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shopper = await _context.Shopper.FindAsync(id);
            _context.Shopper.Remove(shopper);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShopperExists(int id)
        {
            return _context.Shopper.Any(e => e.ShopperId == id);
        }

        public async Task<IActionResult> Location(Shopper shopper)
        {
            if(ModelState.IsValid)
            {
                shopper = await _geocodingService.AttachLatAndLong(shopper);
                _context.Shopper.Add(shopper);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
