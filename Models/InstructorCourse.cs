namespace LMS.Models
{
    public class InstructorCourse
    {
        public int InstructorId { get; set; }
        public int CourseId { get; set; }

        public Instructor Instructor { get; set; }
        public Course Course { get; set; }

        public double RateHour { get; set; }
    }
}