using LMS.Data;
using LMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LMS.Controllers
{
    public class AssignmentController : Controller
    {
        private readonly LmsContext _context;
        private readonly UserManager<User> _userManager;

        public AssignmentController(LmsContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        //Here Assignment list view for Index page
        [Authorize(Roles = "Instructor")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var instructorId = _userManager.GetUserId(User);

            var assignments = await _context.Assignments
                .Include(a => a.Course)
                .Where(a => !a.Deleted && a.Course.InstructorId == instructorId)
                .OrderByDescending(a => a.CreatedDate)
                .ToListAsync();

            return View(assignments);
        }

        //Here Assignment details view for Details page
        [Authorize(Roles = "Instructor")]
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var assignment = await _context.Assignments
                .Include(a => a.Course)
                .FirstOrDefaultAsync(m => m.Id == id && !m.Deleted);
            if (assignment == null)
            {
                return NotFound();
            }
            return View(assignment);
        }
        //Here Assignment creation view for Create page
        [Authorize(Roles = "Instructor")]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var instructorId = _userManager.GetUserId(User);

            var courses = await _context.Courses
                .Where(c => c.InstructorId == instructorId)
                .ToListAsync();

            ViewBag.Courses = new SelectList(courses, "Id", "Title");

            return View();
        }
        //Here Assignment creation action for Create page
        [Authorize(Roles = "Instructor")]
        [HttpPost]
        public async Task<IActionResult> Create(Assignment assignment)
        {
            var instructorId = _userManager.GetUserId(User);

            var course = await _context.Courses
                .FirstOrDefaultAsync(c => c.Id == assignment.CourseId && c.InstructorId == instructorId);

            if (course == null)
                return Unauthorized();

            //if (ModelState.IsValid)
            //{
            //    assignment.CreatedDate = DateTime.UtcNow;
                assignment.Deleted = false;

                _context.Assignments.Add(assignment);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Assignment created successfully!";
                return RedirectToAction(nameof(Index));
            //}

            //ViewBag.Courses = new SelectList(
            //    _context.Courses.Where(c => c.InstructorId == instructorId),
            //    "Id",
            //    "Title",
            //    assignment.CourseId
            //);

            return View(assignment);
        }
        //Here Assignment Edit view for Edit page 
        [Authorize(Roles = "Instructor")]
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var instructorId = _userManager.GetUserId(User);
            var assignment = await _context.Assignments
                .Include(a => a.Course)
                .FirstOrDefaultAsync(a => a.Id == id && !a.Deleted && a.Course.InstructorId == instructorId);
            if (assignment == null)
            {
                return NotFound();
            }
            ViewBag.Courses = new SelectList(
                _context.Courses.Where(c => c.InstructorId == instructorId),
                "Id",
                "Title",
                assignment.CourseId
            );
            return View(assignment);
        }
        //Here Assignment Edit action for Edit page
        [Authorize(Roles = "Instructor")]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Assignment assignment)
        {
            if (id != assignment.Id)
            {
                return NotFound();
            }
            var instructorId = _userManager.GetUserId(User);
            var course = await _context.Courses
                .FirstOrDefaultAsync(c => c.Id == assignment.CourseId && c.InstructorId == instructorId);
            if (course == null)
                return Unauthorized();
            //if (ModelState.IsValid)
            //{
            try
            {
                _context.Update(assignment);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Assignment updated successfully!";
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssignmentExists(assignment.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
            //}
            ViewBag.Courses = new SelectList(
                _context.Courses.Where(c => c.InstructorId == instructorId),
                "Id",
                "Title",
                assignment.CourseId
            );
            return View(assignment);
        }
        private bool AssignmentExists(int id)
        {
            return _context.Assignments.Any(e => e.Id == id && !e.Deleted);
        }
        //Here Assignment Deletion view for delete page
        [Authorize(Roles = "Instructor")]
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var instructorId = _userManager.GetUserId(User);
            var assignment = await _context.Assignments
                .Include(a => a.Course)
                .FirstOrDefaultAsync(a => a.Id == id && !a.Deleted && a.Course.InstructorId == instructorId);
            if (assignment == null)
            {
                return NotFound();
            }
            return View(assignment);
        }
        //Here Assignment Deletion action for delete page
        [Authorize(Roles = "Instructor")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var instructorId = _userManager.GetUserId(User);
            var assignment = await _context.Assignments
                .Include(a => a.Course)
                .FirstOrDefaultAsync(a => a.Id == id && !a.Deleted && a.Course.InstructorId == instructorId);
            if (assignment == null)
            {
                return NotFound();
            }
            assignment.Deleted = true;
            _context.Update(assignment);
            await _context.SaveChangesAsync();
            TempData["Success"] = "Assignment deleted successfully!";
            return RedirectToAction(nameof(Index));

        }
    }
}
