using LMS.Data;
using LMS.Models;
using LMS.Models.Enums;
using LMS.Models.ViewModels;
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
        // Here pending assignment list view for pending assignment page
        //[Authorize(Roles = "Instructor")]
        //[HttpGet]
        //public async Task<IActionResult> PendingAssignments()
        //{
        //    var instructorId = _userManager.GetUserId(User);

        //    var pendingAssignments = await _context.StudentAssignments
        //        .Include(s => s.Assignment)
        //        .ThenInclude(a => a.Course)
        //        .Include(s => s.Student)
        //        .Where(s =>
        //            s.Status == AssignmentStatus.Pending &&
        //            s.Assignment.Course.InstructorId == instructorId
        //        )
        //        .Select(s => new PendingAssignmentViewModel
        //        {
        //            StudentAssignmentId = s.AssignmentId, // FIXED
        //            StudentName = s.Student.Name,
        //            AssignmentTitle = s.Assignment.Title,
        //            CourseTitle = s.Assignment.Course.Title,

        //            // FIX: use correct field from your model
        //            //SubmittedDate = s.SubmissionDate,

        //            Status = (int)s.Status // cast enum to int for ViewModel
        //        })
        //        .ToListAsync();

        //    return View("PendingAssignments", pendingAssignments);
        //}
        [Authorize(Roles = "Instructor")]
        [HttpGet]
        public async Task<IActionResult> PendingAssignments()
        {
            var instructorId = _userManager.GetUserId(User);

            var pendingAssignments = await _context.StudentAssignments
                .Include(s => s.Assignment)
                .ThenInclude(a => a.Course)
                .Include(s => s.Student)
                .Where(s =>
                    //s.Status == AssignmentStatus.Pending &&
                    s.Assignment.Course.InstructorId == instructorId
                ).Select(s => new PendingAssignmentViewModel
                {
                    StudentId = s.StudentId,
                    AssignmentId = s.AssignmentId,
                    StudentName = s.Student.Name,
                    AssignmentTitle = s.Assignment.Title,
                    CourseTitle = s.Assignment.Course.Title,
                    AssignmentMark = s.Assignment.MaxPoints,
                    EarnedMark = s.PointsEarned,
                    SubmittedDate = s.SubmissionDate,
                    Feedback = s.Feedback,
                    Status = (int)s.Status
                })
                //.Select(s => new PendingAssignmentViewModel
                //{
                //    StudentAssignmentId = s.AssignmentId, //  FIXED
                //    StudentName = s.Student.Name,
                //    AssignmentTitle = s.Assignment.Title,
                //    CourseTitle = s.Assignment.Course.Title,
                //    AssignmentMark = s.Assignment.MaxPoints,
                //    //EarnedMark = s.EarnedMark,
                //    //SubmittedDate = s.SubmissionDate, //  FIXED
                //    Feedback = s.Feedback,
                //    Status = (int)s.Status
                //})
                .ToListAsync();

            return View(pendingAssignments);
        }
        // Here pending assignment approval action for pending assignment page
        //[Authorize(Roles = "Instructor")]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Approve(int id)
        //{
        //    var instructorId = _userManager.GetUserId(User);

        //    var studentAssignment = await _context.StudentAssignments
        //        .Include(s => s.Assignment)
        //        .ThenInclude(a => a.Course)
        //        .FirstOrDefaultAsync(s => s.AssignmentId == id);
        //        //    s.StudentAssignmentId == id &&
        //        //    s.Assignment.Course.InstructorId == instructorId
        //        //);

        //    if (studentAssignment == null)
        //    {
        //        return NotFound();
        //    }

        //    studentAssignment.Status = AssignmentStatus.Approved;

        //    _context.StudentAssignments.Update(studentAssignment);
        //    await _context.SaveChangesAsync();

        //    TempData["Success"] = "Assignment approved successfully!";

        //    return RedirectToAction("PendingAssignments");
        //}
        //[Authorize(Roles = "Instructor")]
        //[HttpPost]
        ////[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Approve(string studentId, int assignmentId, int earnedMark, string feedback)
        //{
        //    var instructorId = _userManager.GetUserId(User);

        //    var submission = await _context.StudentAssignments
        //        .Include(s => s.Assignment)
        //        .ThenInclude(a => a.Course)
        //        .FirstOrDefaultAsync(s =>
        //            s.StudentId == studentId &&
        //            s.AssignmentId == assignmentId &&
        //            s.Assignment.Course.InstructorId == instructorId
        //        );

        //    if (submission == null)
        //        return NotFound();

        //    submission.PointsEarned = earnedMark;
        //    submission.Feedback = feedback;
        //    submission.Status = AssignmentStatus.Approved;

        //    await _context.SaveChangesAsync();

        //    TempData["Success"] = "Assignment approved with marks!";
        //    return RedirectToAction("PendingAssignments");
        //}
        [Authorize(Roles = "Instructor")]
        [HttpPost]
        public async Task<IActionResult> Approve(string studentId, int assignmentId, int earnedMark, string feedback)
        {
            var instructorId = _userManager.GetUserId(User);

            var submission = await _context.StudentAssignments
                .Include(s => s.Assignment)
                .ThenInclude(a => a.Course)
                .FirstOrDefaultAsync(s =>
                    s.StudentId == studentId &&
                    s.AssignmentId == assignmentId &&
                    s.Assignment.Course.InstructorId == instructorId
                );

            if (submission == null)
                return NotFound();

            submission.PointsEarned = earnedMark;
            submission.Feedback = feedback;
            submission.Status = AssignmentStatus.Approved;

            await _context.SaveChangesAsync();

            TempData["Success"] = "Assignment approved!";
            return RedirectToAction("PendingAssignments");
        }
        //Here pending assignment rejection action for pending assignment page
        [Authorize(Roles = "Instructor")]
        [HttpPost]
        public async Task<IActionResult> Reject(string studentId, int assignmentId)
        {
            var submission = await _context.StudentAssignments
                .FirstOrDefaultAsync(s =>
                    s.StudentId == studentId &&
                    s.AssignmentId == assignmentId
                );

            if (submission == null)
                return NotFound();

            submission.Status = AssignmentStatus.Rejected;

            await _context.SaveChangesAsync();

            TempData["Success"] = "Assignment rejected!";
            return RedirectToAction("PendingAssignments");
        }
        // Here pending assignment details view for pending assignment page
        [Authorize(Roles = "Instructor")]
        [HttpGet]
        public async Task<IActionResult> AssignmentDetails(int id)
        {
            var data = await _context.StudentAssignments
                .Include(s => s.Assignment)
                .ThenInclude(a => a.Course)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(s => s.AssignmentId == id);

            if (data == null)
                return NotFound();

            return View(data);
        }
    }
}