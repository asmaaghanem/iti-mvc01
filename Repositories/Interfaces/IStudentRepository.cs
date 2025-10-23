using LMS.Models;

namespace LMS.Repositories.Interfaces
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        Student? GetStudentWithRelationsbySSn(int ssn);
    }
}