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
using System.Net.NetworkInformation;


namespace LMS.Controllers
{
   
    public class DashboardController : Controller
    {
        private readonly LmsContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public DashboardController(LmsContext context, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        //Here coding for instructor dashboard
        [Authorize(Roles = "Instructor")]
        public async Task<IActionResult> Instructor()
        {
            // Get logged-in user (BEST WAY)
            
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
                .Include(sa => sa.Assignment)
                .Where(sa =>
                    sa.Assignment != null &&
                    courseIds.Contains(sa.Assignment.CourseId) &&
                    sa.Status == AssignmentStatus.Pending)
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
        //Here coding for student dashboard
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> Student()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return RedirectToAction("Login", "Login");
            }

            // Get enrolled courses
            var enrolledCourses = await _context.StudentCourses
                .Where(sc => sc.StudentId == user.Id)
                .Include(sc => sc.Course)
                .ThenInclude(c => c.Assignments)
                .Select(sc => sc.Course)
                .ToListAsync();

            var courseIds = enrolledCourses.Select(c => c.Id).ToList();

            // Total assignments
            var totalAssignments = await _context.Assignments
                .Where(a => courseIds.Contains(a.CourseId))
                .CountAsync();

            // Completed assignments
            var completedAssignments = await _context.StudentAssignments
                .Where(sa =>
                    sa.StudentId == user.Id &&
                    sa.Status == AssignmentStatus.Submitted)
                .CountAsync();

            // Pending assignments
            var pendingAssignments = await _context.StudentAssignments
                .Where(sa =>
                    sa.StudentId == user.Id &&
                    sa.Status == AssignmentStatus.Pending)
                .CountAsync();

            // Grade progress (simple % calculation)
            decimal gradeProgress = 0;
            if (totalAssignments > 0)
            {
                gradeProgress = (decimal)completedAssignments / totalAssignments * 100;
            }

            var vm = new DashboardViewModel
            {
                CurrentUser = user,
                Role = "Student",

                // Student data
                EnrolledCourses = enrolledCourses,
                TotalAssignments = totalAssignments,
                CompletedAssignments = completedAssignments,
                PendingAssignments = pendingAssignments,
                GradeProgress = gradeProgress
            };

            return View(vm);
        }
    }
}