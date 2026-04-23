using LMS.Models.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LMS.Models
{
    public class User: IdentityUser
    {
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        public UserRole Role { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public ICollection<Course> Courses { get; set; }
        public ICollection<StudentCourse> CourseEnrollments { get; set; }
        public ICollection<StudentAssignment> AssignmentSubmissions { get; set; }
    }
}
