using LMS.Data;
using LMS.Models;
using LMS.Models.ViewModels;
using LMS.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LMS.Pages.Dashboard
{
    [Authorize(Roles = "Instructor")]
    public class InstructorModel : PageModel
    {
        private readonly LmsContext _context;
        private readonly UserManager<User> _userManager;

        public InstructorModel(LmsContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public DashboardViewModel Dashboard { get; set; } = new DashboardViewModel();

        public async Task OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
                return;

            var courses = await _context.Courses
                .Where(c => c.InstructorId == user.Id)
                .Include(c => c.StudentEnrollments)
                .Include(c => c.Assignments)
                .ToListAsync();

            var totalStudents = await _context.StudentCourses
                .Where(sc => courses.Select(c => c.Id).Contains(sc.CourseId))
                .Select(sc => sc.StudentId)
                .Distinct()
                .CountAsync();

            var totalAssignments = await _context.Assignments
                .Where(a => courses.Select(c => c.Id).Contains(a.CourseId))
                .CountAsync();

            var pendingAssignments = await _context.StudentAssignments
                .Where(sa => sa.Status == AssignmentStatus.Pending)
                .CountAsync();

            Dashboard = new DashboardViewModel
            {
                CurrentUser = user,
                Role = "Instructor",
                TotalCourses = courses.Count,
                TotalStudents = totalStudents,
                TotalAssignments = totalAssignments,
                PendingAssignments = pendingAssignments
            };
        }
    }
}