using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Models;

namespace ShoppingCart.Controllers
{
    public class MobilesController : Controller
    {
        private readonly Class5DBContext _context;

        public MobilesController(Class5DBContext context)
        {
            _context = context;
        }

        // GET: Mobiles
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mobiles.ToListAsync());
        }

        // GET: Mobiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mobiles = await _context.Mobiles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mobiles == null)
            {
                return NotFound();
            }

            return View(mobiles);
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
        public async Task<IActionResult> Create([Bind("Id,MobileName,Price,Url,ZoomUrl,Description")] Mobiles mobiles)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mobiles);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mobiles);
        }

        // GET: Mobiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mobiles = await _context.Mobiles.FindAsync(id);
            if (mobiles == null)
            {
                return NotFound();
            }
            return View(mobiles);
        }

        // POST: Mobiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MobileName,Price,Url,ZoomUrl,Description")] Mobiles mobiles)
        {
            if (id != mobiles.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mobiles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MobilesExists(mobiles.Id))
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
            return View(mobiles);
        }

        // GET: Mobiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mobiles = await _context.Mobiles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mobiles == null)
            {
                return NotFound();
            }

            return View(mobiles);
        }

        // POST: Mobiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mobiles = await _context.Mobiles.FindAsync(id);
            if (mobiles != null)
            {
                _context.Mobiles.Remove(mobiles);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MobilesExists(int id)
        {
            return _context.Mobiles.Any(e => e.Id == id);
        }
    }
}
