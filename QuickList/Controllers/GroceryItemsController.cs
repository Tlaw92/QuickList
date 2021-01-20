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
    public class GroceryItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GroceryItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GroceryItems/ItemsSearch
        public async Task<IActionResult> ItemsSearch()
        {
            return View(await _context.GroceryItems.ToListAsync());
        }

        // GET: GroceryItems
        public async Task<IActionResult> Index()
        {
            return View(await _context.GroceryItems.ToListAsync());
        }

        // GET: GroceryItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groceryItems = await _context.GroceryItems
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (groceryItems == null)
            {
                return NotFound();
            }

            return View(groceryItems);
        }

        // GET: GroceryItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GroceryItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemId,ProductId,RealCost")] GroceryItems groceryItems)
        {
            if (ModelState.IsValid)
            {
                _context.Add(groceryItems);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(groceryItems);
        }

        // GET: GroceryItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groceryItems = await _context.GroceryItems.FindAsync(id);
            if (groceryItems == null)
            {
                return NotFound();
            }
            return View(groceryItems);
        }

        // POST: GroceryItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemId,ProductId,RealCost")] GroceryItems groceryItems)
        {
            if (id != groceryItems.ItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(groceryItems);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroceryItemsExists(groceryItems.ItemId))
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
            return View(groceryItems);
        }

        // GET: GroceryItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groceryItems = await _context.GroceryItems
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (groceryItems == null)
            {
                return NotFound();
            }

            return View(groceryItems);
        }

        // POST: GroceryItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var groceryItems = await _context.GroceryItems.FindAsync(id);
            _context.GroceryItems.Remove(groceryItems);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroceryItemsExists(int id)
        {
            return _context.GroceryItems.Any(e => e.ItemId == id);
        }
    }
}
