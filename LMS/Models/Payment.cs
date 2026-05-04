namespace LMS.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public int CourseId { get; set; }
        public string Method { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
