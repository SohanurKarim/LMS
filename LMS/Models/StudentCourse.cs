namespace LMS.Models
{
    public class StudentCourse    {
   
        public string StudentId { get; set; }
       
        public User Student { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public decimal? Grade { get; set; }
    }
}
