using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using T2301EAssignment.Models;
using T2301EAssignment.Models.DTOs;

namespace T2301EAssignment.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly T2301EDBContext _context;

        public EmployeesController(T2301EDBContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var t2301EDBContext = _context.Employee_Tbl.Include(e => e.Department);
            return View(await t2301EDBContext.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee_Tbl
                .Include(e => e.Department)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Department_Tbl, "Id", "Id");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeName,EmployeeCode,Rank,DepartmentId")] EmployeeDTO employeeDTO)
        {
            Employee employee = null;
            if (ModelState.IsValid)
            {
				employee = new Employee
				{
					EmployeeName = employeeDTO.EmployeeName,
					EmployeeCode = employeeDTO.EmployeeCode,
					Rank = employeeDTO.Rank,
					DepartmentId = employeeDTO.DepartmentId
				};
				_context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_context.Department_Tbl, "Id", "Id", employeeDTO.DepartmentId);
            return View(employee);
        }

		// GET: Employees/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var employee = await _context.Employee_Tbl.FindAsync(id);
			if (employee == null)
			{
				return NotFound();
			}

			// Populate the dropdown list with department names
			ViewData["DepartmentId"] = new SelectList(_context.Department_Tbl, "Id", "Id", employee.DepartmentId);

			return View(employee);
		}


		// POST: Employees/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeName,EmployeeCode,Rank,DepartmentId")] EmployeeDTO employeeDTO)
		{
			if (id != employeeDTO.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					var employee = await _context.Employee_Tbl.FindAsync(id);
					if (employee == null)
					{
						return NotFound();
					}

					// Update employee properties
					employee.EmployeeName = employeeDTO.EmployeeName;
					employee.EmployeeCode = employeeDTO.EmployeeCode;
					employee.Rank = employeeDTO.Rank;
					employee.DepartmentId = employeeDTO.DepartmentId;

					_context.Update(employee);
					await _context.SaveChangesAsync();
					return RedirectToAction(nameof(Index));
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!EmployeeExists(employeeDTO.Id))
					{
						return NotFound();
					}
					else
					{
						ModelState.AddModelError("", "Concurrency conflict occurred. Please try again.");
						return View(employeeDTO); // Return to the edit view with the updated employeeDTO and error message
					}
				}
			}

			// If ModelState is not valid, repopulate the dropdown list and return to the edit view
			ViewData["DepartmentId"] = new SelectList(_context.Department_Tbl, "Id", "Id", employeeDTO.DepartmentId);
			return View(employeeDTO);
		}


		// GET: Employees/Delete/5
		public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee_Tbl
                .Include(e => e.Department)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employee_Tbl.FindAsync(id);
            if (employee != null)
            {
                _context.Employee_Tbl.Remove(employee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee_Tbl.Any(e => e.Id == id);
        }
    }
}
