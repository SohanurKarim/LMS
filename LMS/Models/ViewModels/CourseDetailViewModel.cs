using LMS.Models;

namespace LMS.Models.ViewModels
{
    public class CourseDetailViewModel
    {
      
        // COURSE BASIC INFO        
        public Course Course { get; set; }
     
        // INSTRUCTOR INFO     
        public User Instructor { get; set; }
     
        // ASSIGNMENTS IN THIS COURSE    
        public List<Assignment> Assignments { get; set; }

        // ENROLLED STUDENTS
        public List<StudentCourse> Enrollments { get; set; }

        // OPTIONAL: CURRENT USER STATUS          
        public bool IsEnrolled { get; set; }

        public string CurrentUserId { get; set; }

        // STATISTICS (FOR UI DASHBOARD)
     
        public int TotalStudents => Enrollments?.Count ?? 0;

        public int TotalAssignments => Assignments?.Count ?? 0;

        public int CompletedAssignmentsCount { get; set; }

        public decimal ProgressPercentage
        {
            get
            {
                if (TotalAssignments == 0) return 0;
                if (TotalStudents == 0) return 0;

                return (decimal)CompletedAssignmentsCount / TotalAssignments * 100;
            }
        }
    }
}