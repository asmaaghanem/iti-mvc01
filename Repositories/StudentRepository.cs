using LMS.Context;
using LMS.Models;
using LMS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;

namespace LMS.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        private readonly LMSContext context;

        public StudentRepository(LMSContext _context) : base(_context)
        {
            context = _context;
        }

        public Student? GetStudentWithRelationsbySSn(int ssn)
        {
            return context.Students
                .Include(s => s.Department)
                .Include(s => s.StudentCourses)
                .ThenInclude(sc => sc.Course)
                .FirstOrDefault(s => s.SSN == ssn);
        }
    }
}