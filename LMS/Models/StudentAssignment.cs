using LMS.Models.Enums;

namespace LMS.Models
{
    public class StudentAssignment
    {
      
        public string StudentId { get; set; }

        public User Student { get; set; }

        public int AssignmentId { get; set; }
        public Assignment Assignment { get; set; }

        public DateTime? SubmissionDate { get; set; }

        public decimal? PointsEarned { get; set; }

        public AssignmentStatus Status { get; set; }

        public string? Feedback { get; set; }
    }
}
