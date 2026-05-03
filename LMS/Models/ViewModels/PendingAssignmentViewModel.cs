namespace LMS.Models.ViewModels
{
    //public class PendingAssignmentViewModel
    //{
    //    public int StudentAssignmentId { get; set; }
    //    public string StudentName { get; set; }
    //    public string AssignmentTitle { get; set; }
    //    public string CourseTitle { get; set; }      
    //    public int AssignmentMark { get; set; }
    //    public int EarnedMark { get; set; }
    //    public DateTime SubmittedDate { get; set; }
    //    public string Feedback { get; set; }
    //    public int Status { get; set; }
    //}
    public class PendingAssignmentViewModel
    {
        public string StudentId { get; set; }     
        public int AssignmentId { get; set; }   

        public string StudentName { get; set; }
        public string AssignmentTitle { get; set; }
        public string CourseTitle { get; set; }
        public decimal AssignmentMark { get; set; }
        public decimal? EarnedMark { get; set; }
        public DateTime? SubmittedDate { get; set; }
        public string Feedback { get; set; }
        public int Status { get; set; }
    }
}
