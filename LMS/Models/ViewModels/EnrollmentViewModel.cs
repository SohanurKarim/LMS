using LMS.Models;

namespace LMS.Models.ViewModels
{
    public class EnrollmentViewModel
    {       
        // COURSE INFO      
        public Course Course { get; set; }
      
        // STUDENT INFO      
        public List<User> Students { get; set; }

        // Students already enrolled in this course
        public List<StudentCourse> EnrolledStudents { get; set; }
     
        // ENROLLMENT ACTION DATA   
        public string SelectedStudentId { get; set; }

        public int CourseId { get; set; }

      
        // UI HELPERS        
        public bool IsEnrolled(string studentId)
        {
            return EnrolledStudents != null &&
                   EnrolledStudents.Any(e => e.StudentId == studentId);
        }

        public int TotalEnrolled => EnrolledStudents?.Count ?? 0;

        public int MaxCapacity => Course?.MaxEnrollment ?? 0;

        public bool IsFull => TotalEnrolled >= MaxCapacity;
    }
}