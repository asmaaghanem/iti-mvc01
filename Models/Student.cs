using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Models
{
    public class Student
    {
        [Key]
        public int SSN { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Range(2, 60)]
        public int Age { get; set; }

        public string Address { get; set; }

        public string ImageURL { get; set; }

        public int DepartmentId { get; set; }

        public Department? Department { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
    }
}