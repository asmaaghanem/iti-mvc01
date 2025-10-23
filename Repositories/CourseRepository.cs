using LMS.Context;
using LMS.Models;
using LMS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LMS.Repositories
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        private readonly LMSContext context;

        public CourseRepository(LMSContext _context) : base(_context)
        {
            context = _context;
        }

        public Course? GetCourseWithRelations(int id)
        {
            return context.Courses
                 .Include(c => c.StudentCourses)
                     .ThenInclude(sc => sc.Student)
                 .Include(c => c.InstructorCourses)
                     .ThenInclude(ic => ic.Instructor)
                 .FirstOrDefault(c => c.Id == id);
        }
    }
}