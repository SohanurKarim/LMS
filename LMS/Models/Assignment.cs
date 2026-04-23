using System.ComponentModel.DataAnnotations;

namespace LMS.Models
{
    public class Assignment
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int MaxPoints { get; set; }

        public DateTime DueDate { get; set; }
       
        public DateTime CreatedDate { get; set; }
        public bool Deleted { get; set; }

        public ICollection<StudentAssignment> StudentAssignments { get; set; }
    }
}
