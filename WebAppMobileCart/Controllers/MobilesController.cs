﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppMobile.Models;

namespace WebAppMobile.Controllers
{
    public class MobilesController : Controller
    {
        private readonly MobileShoppingContext _context;

        public MobilesController(MobileShoppingContext context)
        {
            _context = context;
        }

        // GET: Mobiles
        public async Task<IActionResult> Index()
        {
              return _context.Mobiles != null ? 
                          View(await _context.Mobiles.ToListAsync()) :
                          Problem("Entity set 'MobileShoppingContext.Mobiles'  is null.");
        }

        // GET: Mobiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Mobiles == null)
            {
                return NotFound();
            }

            var mobile = await _context.Mobiles
                .FirstOrDefaultAsync(m => m.SlNo == id);
            if (mobile == null)
            {
                return NotFound();
            }

            return View(mobile);
        }

        // GET: Mobiles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mobiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SlNo,MobileName,Price,Url,Description,ZoomUrl")] Mobile mobile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mobile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mobile);
        }

        // GET: Mobiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Mobiles == null)
            {
                return NotFound();
            }

            var mobile = await _context.Mobiles.FindAsync(id);
            if (mobile == null)
            {
                return NotFound();
            }
            return View(mobile);
        }

        // POST: Mobiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SlNo,MobileName,Price,Url,Description,ZoomUrl")] Mobile mobile)
        {
            if (id != mobile.SlNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mobile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MobileExists(mobile.SlNo))
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
            return View(mobile);
        }

        // GET: Mobiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Mobiles == null)
            {
                return NotFound();
            }

            var mobile = await _context.Mobiles
                .FirstOrDefaultAsync(m => m.SlNo == id);
            if (mobile == null)
            {
                return NotFound();
            }

            return View(mobile);
        }

        // POST: Mobiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Mobiles == null)
            {
                return Problem("Entity set 'MobileShoppingContext.Mobiles'  is null.");
            }
            var mobile = await _context.Mobiles.FindAsync(id);
            if (mobile != null)
            {
                _context.Mobiles.Remove(mobile);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MobileExists(int id)
        {
          return (_context.Mobiles?.Any(e => e.SlNo == id)).GetValueOrDefault();
        }
    }
}
