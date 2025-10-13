using Microsoft.EntityFrameworkCore;
using studentController.Models;

namespace studentController.Context
{
    public class StudentContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=StudentDB;Trusted_Connection=True;Encrypt=false");
        }

        public DbSet<Student> Students { get; set; }
    }
}
        
