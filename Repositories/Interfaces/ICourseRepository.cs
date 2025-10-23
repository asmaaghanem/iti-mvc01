using LMS.Models;

namespace LMS.Repositories.Interfaces
{
    public interface ICourseRepository : IGenericRepository<Course>
    {
        Course? GetCourseWithRelations(int id);
    }
}