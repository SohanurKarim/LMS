using System.ComponentModel.DataAnnotations;

namespace LMS.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Title { get; set; }

        public string Description { get; set; }
       
        public string InstructorId { get; set; }
        
        public User Instructor { get; set; }
        public int Credits { get; set; }

        public int MaxEnrollment { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public DateTime CreatedDate { get; set; }

        public ICollection<StudentCourse> StudentEnrollments { get; set; }
        public ICollection<Assignment> Assignments { get; set; }
    }
}
