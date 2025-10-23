using LMS.Validators;
using System.ComponentModel.DataAnnotations;

namespace LMS.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [UniqueName]
        public string Name { get; set; }

        public string Topic { get; set; }

        [Degree]
        public double Degree { get; set; }

        public double MinDegree { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
        public ICollection<InstructorCourse> InstructorCourses { get; set; } = new List<InstructorCourse>();
    }
}