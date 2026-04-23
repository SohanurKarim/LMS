using LMS.Models;

namespace LMS.Models.ViewModels
{
    public class DashboardViewModel
    {
     
        // USER INFO    
        public User CurrentUser { get; set; }

        public string Role { get; set; }
       
        // INSTRUCTOR DASHBOARD DATA    
        public int TotalCourses { get; set; }

        public int TotalStudents { get; set; }

        public int TotalAssignments { get; set; }

        public int PendingAssignments { get; set; }

        // STUDENT DASHBOARD DATA
        public List<Course> EnrolledCourses { get; set; }

        public int CompletedAssignments { get; set; }

        public int TotalEnrolledCourses => EnrolledCourses?.Count ?? 0;

        public decimal GradeProgress { get; set; }

        // UI HELPERS 
        public bool IsInstructor => Role == "Instructor";

        public bool IsStudent => Role == "Student";
    }
}