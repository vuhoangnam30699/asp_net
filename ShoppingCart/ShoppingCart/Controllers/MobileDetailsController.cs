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
    public class MobileDetailsController : Controller
    {
        private readonly Class5DBContext _context;

        public MobileDetailsController(Class5DBContext context)
        {
            _context = context;
        }

        // GET: MobileDetails
        public async Task<IActionResult> Index()
        {
            var class5DBContext = _context.MobileDetails.Include(m => m.Mobile);
            return View(await class5DBContext.ToListAsync());
        }

        // GET: MobileDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mobileDetails = await _context.MobileDetails
                .Include(m => m.Mobile)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mobileDetails == null)
            {
                return NotFound();
            }

            return View(mobileDetails);
        }

        // GET: MobileDetails/Create
        public IActionResult Create()
        {
            ViewData["MobileId"] = new SelectList(_context.Mobiles, "Id", "Id");
            return View();
        }

        // POST: MobileDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MobileId,Features,Model,Color,SimType")] MobileDetails mobileDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mobileDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MobileId"] = new SelectList(_context.Mobiles, "Id", "Id", mobileDetails.MobileId);
            return View(mobileDetails);
        }

        // GET: MobileDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mobileDetails = await _context.MobileDetails.FindAsync(id);
            if (mobileDetails == null)
            {
                return NotFound();
            }
            ViewData["MobileId"] = new SelectList(_context.Mobiles, "Id", "Id", mobileDetails.MobileId);
            return View(mobileDetails);
        }

        // POST: MobileDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MobileId,Features,Model,Color,SimType")] MobileDetails mobileDetails)
        {
            if (id != mobileDetails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mobileDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MobileDetailsExists(mobileDetails.Id))
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
            ViewData["MobileId"] = new SelectList(_context.Mobiles, "Id", "Id", mobileDetails.MobileId);
            return View(mobileDetails);
        }

        // GET: MobileDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mobileDetails = await _context.MobileDetails
                .Include(m => m.Mobile)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mobileDetails == null)
            {
                return NotFound();
            }

            return View(mobileDetails);
        }

        // POST: MobileDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mobileDetails = await _context.MobileDetails.FindAsync(id);
            if (mobileDetails != null)
            {
                _context.MobileDetails.Remove(mobileDetails);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MobileDetailsExists(int id)
        {
            return _context.MobileDetails.Any(e => e.Id == id);
        }
    }
}
