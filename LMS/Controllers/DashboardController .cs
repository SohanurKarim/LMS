//using LMS.Data;
//using LMS.Models;
//using LMS.Models.ViewModels;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;

//namespace LMS.Controllers
//{
//    public class DashboardController : Controller
//    {
//        private readonly LmsContext _context;
//        private readonly UserManager<User> _userManager;

//        public DashboardController(LmsContext context, UserManager<User> userManager)
//        {
//            _context = context;
//            _userManager = userManager;
//        }

//        public async Task<IActionResult> Instructor()
//        {
//            var vm = new DashboardViewModel
//            {
//                //CurrentUser = new User
//                //{
//                //    Name = "Demo User",
//                //    Email = "demo@test.com"
//                //},
//                Role = "Instructor",
//                TotalCourses = 5,
//                TotalStudents = 20,
//                TotalAssignments = 10,
//                PendingAssignments = 3
//            };

//            ViewData["Title"] = "Instructor Dashboard";
//            return View(vm);
//        }
//    }
//}
using LMS.Data;
using LMS.Models;
using LMS.Models.Enums;
using LMS.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMS.Controllers
{
    //[Authorize(Roles = "Instructor")]
    public class DashboardController : Controller
    {
        private readonly LmsContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public DashboardController(LmsContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Instructor()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return RedirectToAction("Login", "Login");
            }

            var courses = await _context.Courses
                .Where(c => c.InstructorId == user.Id)
                .Include(c => c.StudentEnrollments)
                .Include(c => c.Assignments)
                .ToListAsync();

            var courseIds = courses.Select(c => c.Id).ToList();

            var totalStudents = await _context.StudentCourses
                .Where(sc => courseIds.Contains(sc.CourseId))
                .Select(sc => sc.StudentId)
                .Distinct()
                .CountAsync();

            var totalAssignments = await _context.Assignments
                .Where(a => courseIds.Contains(a.CourseId))
                .CountAsync();

            var pendingAssignments = await _context.StudentAssignments
                .Where(sa => courseIds.Contains(sa.Assignment.CourseId)
                          && sa.Status == AssignmentStatus.Pending)
                .CountAsync();

            var vm = new DashboardViewModel
            {
                CurrentUser = user,
                Role = "Instructor",
                TotalCourses = courses.Count,
                TotalStudents = totalStudents,
                TotalAssignments = totalAssignments,
                PendingAssignments = pendingAssignments
            };

            return View(vm);
        }
    }
}