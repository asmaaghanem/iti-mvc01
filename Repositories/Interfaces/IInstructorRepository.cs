using LMS.Models;

namespace LMS.Repositories.Interfaces
{
    public interface IInstructorRepository : IGenericRepository<Instructor>
    {
        Instructor? GetInstructorWithRelations(int id);
    }
}