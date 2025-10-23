using LMS.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LMS.Context
{
    public class LMSContext : IdentityDbContext<ApplicationUser>
    {
        public LMSContext() : base()
        {
        }

        public LMSContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<InstructorCourse>().HasKey(ic => new { ic.CourseId, ic.InstructorId });
            modelBuilder.Entity<StudentCourse>().HasKey(sc => new { sc.CourseId, sc.StudentSSN });

            modelBuilder.Entity<InstructorCourse>().HasOne(ic => ic.Course).WithMany(c => c.InstructorCourses).HasForeignKey(ic => ic.CourseId);
            modelBuilder.Entity<InstructorCourse>().HasOne(ic => ic.Instructor).WithMany(i => i.InstructorCourses).HasForeignKey(ic => ic.InstructorId);

            modelBuilder.Entity<StudentCourse>().HasOne(sc => sc.Course).WithMany(c => c.StudentCourses).HasForeignKey(sc => sc.CourseId);
            modelBuilder.Entity<StudentCourse>().HasOne(sc => sc.Student).WithMany(i => i.StudentCourses).HasForeignKey(sc => sc.StudentSSN);
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<InstructorCourse> InstructorsCourse { get; set; }
        public DbSet<StudentCourse> StudentsCourses { get; set; }
    }
}