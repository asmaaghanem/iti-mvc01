using LMS.Models;

namespace LMS.Repositories.Interfaces
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
        Department? GetDepartmentWithRelations(int id);

        Department? GetDepartmentByName(string Name);
    }
}