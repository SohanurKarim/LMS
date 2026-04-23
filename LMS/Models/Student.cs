namespace LMS.Models
{
    public class Student : User
    {
        // Student-Courses 
        public ICollection<StudentCourse> CourseEnrollments { get; set; }

        // Student-Assignments 
        public ICollection<StudentAssignment> AssignmentSubmissions { get; set; }
    }
}
