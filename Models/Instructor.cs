using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Models
{
    public class Instructor
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Range(20, 70)]
        public int Age { get; set; }

        public string Address { get; set; }

        public string ImageURL { get; set; }

        [Required]
        public decimal Salary { get; set; }

        public DateOnly HireDate { get; set; }

        public int DepartmentId { get; set; }

        public Department? Department { get; set; }

        public ICollection<InstructorCourse> InstructorCourses { get; set; } = new List<InstructorCourse>();
    }
}