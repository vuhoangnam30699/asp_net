using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Models.DTOs;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly T2301eSem3Context _context;

        public StudentsController(T2301eSem3Context context)
        {
            _context = context;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentGrade>>> GetStudents()
		{
			if (_context.Students == null)
			{
				return NotFound();
			}

            //LINQ


            var studentList = await (from s in _context.Students
                               join g in _context.Grades on s.GradeId equals g.GradeId
                               select new StudentGrade
                               {
								   FirstName = s.FirstName,
								   LastName = s.LastName,
								   GradeId = s.GradeId,
								   Grade = g.GradeName
							   }).ToListAsync();

			if (studentList == null)
			{
				return NotFound();
			}

			return studentList;
		}

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentGrade>> GetStudent(int id)
        {
			var student = await (from s in _context.Students
									 join g in _context.Grades on s.GradeId equals g.GradeId
									 where s.StudentId == id
									 select new StudentGrade
									 {
										 FirstName = s.FirstName,
										 LastName = s.LastName,
										 GradeId = s.GradeId,
										 Grade = g.GradeName
									 }).FirstAsync();

			if (student == null)
            {
                return NotFound();
            }

            return student;
        }

		// PUT: api/Students/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutStudent(int id, StudentDTO studentDTO)
		{
			var student = await _context.Students.FindAsync(id);
			if (student == null)
			{
				return NotFound();
			}

			// Mapping properties from DTO to entity
			student.FirstName = studentDTO.FirstName;
			student.LastName = studentDTO.LastName;
			student.GradeId = studentDTO.GradeId;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!StudentExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/Students
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Student>> PostStudent(StudentDTO studentDTO)
		{
            if(_context.Students == null)
            {
                return Problem("Entity set 'T2301eSem3Context.Students' is null. ");
            }    


            Student student = new Student();
            // mapping
            student.FirstName = studentDTO.FirstName;
            student.LastName = studentDTO.LastName;
            student.GradeId = studentDTO.GradeId;

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudent", new { id = student.StudentId }, student);
		}

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.StudentId == id);
        }
    }
}
