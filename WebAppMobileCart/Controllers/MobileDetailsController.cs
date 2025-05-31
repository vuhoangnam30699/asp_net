using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppMobile.Models;

namespace WebAppMobile.Controllers
{
    public class MobileDetailsController : Controller
    {
        private readonly MobileShoppingContext _context;

        public MobileDetailsController(MobileShoppingContext context)
        {
            _context = context;
        }

        // GET: MobileDetails
        public async Task<IActionResult> Index()
        {
            var mobileShoppingContext = _context.MobileDetails.Include(m => m.Mobile);
            return View(await mobileShoppingContext.ToListAsync());
        }

        // GET: MobileDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MobileDetails == null)
            {
                return NotFound();
            }

            var mobileDetail = await _context.MobileDetails
                .Include(m => m.Mobile)
                .FirstOrDefaultAsync(m => m.Slno == id);
            if (mobileDetail == null)
            {
                return NotFound();
            }

            return View(mobileDetail);
        }

        // GET: MobileDetails/Create
        public IActionResult Create()
        {
            ViewData["MobileId"] = new SelectList(_context.Mobiles, "SlNo", "SlNo");
            return View();
        }

        // POST: MobileDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Slno,MobileId,Features,Model,Color,SimType")] MobileDetail mobileDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mobileDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MobileId"] = new SelectList(_context.Mobiles, "SlNo", "SlNo", mobileDetail.MobileId);
            return View(mobileDetail);
        }

        // GET: MobileDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MobileDetails == null)
            {
                return NotFound();
            }

            var mobileDetail = await _context.MobileDetails.FindAsync(id);
            if (mobileDetail == null)
            {
                return NotFound();
            }
            ViewData["MobileId"] = new SelectList(_context.Mobiles, "SlNo", "SlNo", mobileDetail.MobileId);
            return View(mobileDetail);
        }

        // POST: MobileDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Slno,MobileId,Features,Model,Color,SimType")] MobileDetail mobileDetail)
        {
            if (id != mobileDetail.Slno)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mobileDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MobileDetailExists(mobileDetail.Slno))
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
            ViewData["MobileId"] = new SelectList(_context.Mobiles, "SlNo", "SlNo", mobileDetail.MobileId);
            return View(mobileDetail);
        }

        // GET: MobileDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MobileDetails == null)
            {
                return NotFound();
            }

            var mobileDetail = await _context.MobileDetails
                .Include(m => m.Mobile)
                .FirstOrDefaultAsync(m => m.Slno == id);
            if (mobileDetail == null)
            {
                return NotFound();
            }

            return View(mobileDetail);
        }

        // POST: MobileDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MobileDetails == null)
            {
                return Problem("Entity set 'MobileShoppingContext.MobileDetails'  is null.");
            }
            var mobileDetail = await _context.MobileDetails.FindAsync(id);
            if (mobileDetail != null)
            {
                _context.MobileDetails.Remove(mobileDetail);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MobileDetailExists(int id)
        {
          return (_context.MobileDetails?.Any(e => e.Slno == id)).GetValueOrDefault();
        }
    }
}
