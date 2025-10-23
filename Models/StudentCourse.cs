namespace LMS.Models
{
    public class StudentCourse
    {
        public int StudentSSN { get; set; }
        public int CourseId { get; set; }

        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }

        public double Grade { get; set; }
    }
}