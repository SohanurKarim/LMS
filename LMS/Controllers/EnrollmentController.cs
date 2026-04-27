using LMS.Data;
using LMS.Models;
using LMS.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMS.Controllers
{
    public class EnrollmentController : Controller
    {

        private readonly LmsContext _context;
        private readonly UserManager<User> _userManager;

        public EnrollmentController(LmsContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        //Here student enrollment list show for instructor
        [Authorize(Roles = "Instructor")]
        public async Task<IActionResult> Index()
        {
            var instructorId = _userManager.GetUserId(User);

            if (instructorId == null)
                return Unauthorized();

            // Get all courses of this instructor
            var courses = await _context.Courses
                .Where(c => c.InstructorId == instructorId)
                .ToListAsync();

            var courseIds = courses.Select(c => c.Id).ToList();

            // Get all enrollments for those courses
            var enrollments = await _context.StudentCourses
                .Include(e => e.Student)
                .Include(e => e.Course)
                .Where(e => courseIds.Contains(e.CourseId))
                .ToListAsync();

            return View(enrollments);
        }

        // Here student enrollment manage by instructor for specific course like remove student from course
        [Authorize(Roles = "Instructor")]
        [HttpPost]
        public async Task<IActionResult> Remove(int courseId, string studentId)
        {
            var enrollment = await _context.StudentCourses
                .FirstOrDefaultAsync(e => e.CourseId == courseId && e.StudentId == studentId);
            if (enrollment == null)
                return NotFound();
            _context.StudentCourses.Remove(enrollment);
            await _context.SaveChangesAsync();
            TempData["Success"] = "Student removed successfully!";
            return RedirectToAction("Index", new { courseId });
        }

        //// Here we show the enrollment management page for a specific course, listing all students and their enrollment status
        //public async Task<IActionResult> Index(int courseId)
        //{
        //    var course = await _context.Courses
        //        .FirstOrDefaultAsync(c => c.Id == courseId);

        //    if (course == null)
        //        return NotFound();

        //    var students = await _userManager.GetUsersInRoleAsync("Student");

        //    var enrolled = await _context.StudentCourses
        //        .Where(e => e.CourseId == courseId)
        //        .ToListAsync();

        //    var vm = new EnrollmentViewModel
        //    {
        //        Course = course,
        //        Students = students.ToList(),
        //        EnrolledStudents = enrolled,
        //        CourseId = courseId
        //    };

        //    return View(vm);
        //}
    }
}
