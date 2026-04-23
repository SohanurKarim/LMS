namespace LMS.Models
{
    public class Instructor : User
    {
        public ICollection<Course> CourseNavigationProperty { get; set; }
    }
}
