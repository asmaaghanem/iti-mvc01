using System.ComponentModel.DataAnnotations;

namespace LMS.Models
{
    public class Department
    {
        [Key]
        public int deptId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        public string Manager { get; set; }

        public string Location { get; set; }

        public BranchType Branches { get; set; }

        public ICollection<Student> Students { get; set; } = new List<Student>();
        public ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();
    }
}