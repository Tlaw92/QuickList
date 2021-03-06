﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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

        //GET: GroceryLists
        public ActionResult Index()
        {
            var groceryList = _context.GroceryList.Include(m => m.Shopper).ToList();

            return View(groceryList);
        }
        //public async Task<IActionResult> Index()
        //{
        //    var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    var shopper = _context.Shopper.Where(c => c.IdentityUserId == userId);
        //    if (shopper == null)
        //    {
        //        return RedirectToAction("Create");
        //    }
        //    var applicationDbContext = _context.Shopper.Include(s => s.IdentityUser);
        //    return View(await applicationDbContext.ToListAsync());
        //}

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

            ViewData["ShopperId"] = new SelectList(_context.Shopper, "ShopperId", "ShopperId");
            return View();
        }

        // POST: GroceryLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShopperId,ListName,Budget,RealTotalCost,StoreName,ParkingSpot,Date,City,State,ZipCode")] GroceryList groceryList)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var shopper = _context.Shopper.Where(c => c.IdentityUserId == userId).SingleOrDefault();
                shopper.IdentityUserId = userId;
                _context.Add(groceryList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(groceryList);
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("GroceryListId,ShopperId,EstimatedTotalCost,RealTotalCost,StoreName, Date, City, State, ZipCode")] GroceryList groceryList)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
        //        var shopper = _context.Shopper.Where(c => c.IdentityUserId == userId).SingleOrDefault(); 
        //        _context.GroceryList.Add(groceryList);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(groceryList);
        //}

        // GET: GroceryLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["ShopperId"] = new SelectList(_context.Shopper, "ShopperId", "ShopperId");

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
        public async Task<IActionResult> Edit(int id, [Bind("GroceryListId,ShopperId,ListName,Budget,RealTotalCost,StoreName,ParkingSpot,Date,City,State,ZipCode")] GroceryList groceryList)
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
