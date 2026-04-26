using LMS.Data;
using LMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LMS.Controllers
{
    public class CourseController : Controller
    {
        private readonly LmsContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public CourseController(LmsContext context, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        //Here Course list view for Index page
        [Authorize(Roles = "Instructor")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var courses =  await _context.Courses
                .Where(c => c.InstructorId == _userManager.GetUserId(User))
                .ToListAsync();
            return View(courses);
        }

        //Here Course details view for Details page
        [Authorize(Roles = "Instructor")]
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        //Here Course creation view for Create page
        [Authorize(Roles = "Instructor")]
        [HttpGet]
        public IActionResult Create()
        {
            //ViewBag.InstructorId = new SelectList(_userManager.Users.ToList(), "Id", "UserName");
            return View();
        }

        //Here Course creation logic for Create page
        [Authorize(Roles = "Instructor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description,Credits,MaxEnrollment,StartDate,EndDate")] Course course)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                    var instructorId = _userManager.GetUserId(User);

                    if (instructorId == null)
                    {
                        return Unauthorized();
                    }

                    course.InstructorId = instructorId;
                    course.CreatedDate = DateTime.UtcNow;

                    _context.Add(course);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                //}
                return View(course);
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here using your logging framework
                ModelState.AddModelError(string.Empty, "An error occurred while creating the course. Please try again.");
                return View(course);
            }
        }

        // Here Course editing view for Edit page
        [Authorize(Roles = "Instructor")]
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            //ViewBag.InstructorId = new SelectList(_userManager.Users.ToList(), "Id", "UserName", course.InstructorId);
            return View(course);
        }

        // Here Course editing logic for Edit page
        [Authorize(Roles = "Instructor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Credits,MaxEnrollment,StartDate,EndDate")] Course course)
        {
            if (id != course.Id)
                return NotFound();

            //if (ModelState.IsValid)
            //{
                try
                {
                    var existingCourse = await _context.Courses.FindAsync(id);

                    if (existingCourse == null)
                        return NotFound();

                    existingCourse.Title = course.Title;
                    existingCourse.Description = course.Description;
                    existingCourse.Credits = course.Credits;
                    existingCourse.MaxEnrollment = course.MaxEnrollment;
                    existingCourse.StartDate = course.StartDate;
                    existingCourse.EndDate = course.EndDate;

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.Id))
                        return NotFound();
                    else
                        throw;
                }

                return RedirectToAction(nameof(Index));
            //}

            return View(course);
        }
        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.Id == id);
        }
        // Here Course deletion view for Delete page
        [Authorize(Roles = "Instructor")]
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        //Here Course deletion logic for Delete page
        [Authorize(Roles = "Instructor")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}