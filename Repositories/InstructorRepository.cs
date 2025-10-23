using LMS.Context;
using LMS.Models;
using LMS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LMS.Repositories
{
    public class InstructorRepository : GenericRepository<Instructor>, IInstructorRepository
    {
        private readonly LMSContext context;

        public InstructorRepository(LMSContext _context) : base(_context)
        {
            context = _context;
        }

        public Instructor? GetInstructorWithRelations(int id)
        {
            return context.Instructors
                .Include(i => i.Department)
                .Include(i => i.InstructorCourses)
                .ThenInclude(ic => ic.Course)
                .FirstOrDefault(i => i.Id == id);
        }
    }
}