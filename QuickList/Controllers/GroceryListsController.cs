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
    public class GroceryListsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GroceryListsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GroceryLists
        public async Task<IActionResult> Index()
        {
            return View(await _context.GroceryList.ToListAsync());
        }

        // GET: GroceryLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groceryList = await _context.GroceryList
                .FirstOrDefaultAsync(m => m.GroceryListId == id);
            if (groceryList == null)
            {
                return NotFound();
            }

            return View(groceryList);
        }

        // GET: GroceryLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GroceryLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GroceryListId,ShopperId,EstimatedTotalCost,RealTotalCost,StoreName")] GroceryList groceryList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(groceryList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(groceryList);
        }

        // GET: GroceryLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groceryList = await _context.GroceryList.FindAsync(id);
            if (groceryList == null)
            {
                return NotFound();
            }
            return View(groceryList);
        }

        // POST: GroceryLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GroceryListId,ShopperId,EstimatedTotalCost,RealTotalCost,StoreName")] GroceryList groceryList)
        {
            if (id != groceryList.GroceryListId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(groceryList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroceryListExists(groceryList.GroceryListId))
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
            return View(groceryList);
        }

        // GET: GroceryLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groceryList = await _context.GroceryList
                .FirstOrDefaultAsync(m => m.GroceryListId == id);
            if (groceryList == null)
            {
                return NotFound();
            }

            return View(groceryList);
        }

        // POST: GroceryLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var groceryList = await _context.GroceryList.FindAsync(id);
            _context.GroceryList.Remove(groceryList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroceryListExists(int id)
        {
            return _context.GroceryList.Any(e => e.GroceryListId == id);
        }
    }
}
