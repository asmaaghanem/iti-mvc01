using LMS.Context;
using LMS.Models;
using LMS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LMS.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        private readonly LMSContext context;

        public DepartmentRepository(LMSContext _context) : base(_context)
        {
            context = _context;
        }

        public Department? GetDepartmentByName(string name)
        {
            return context.Departments
                .Include(d => d.Students)
                .Include(d => d.Instructors)
                .FirstOrDefault(d => d.Name == name);
        }

        public Department? GetDepartmentWithRelations(int id)
        {
            return context.Departments
                .Include(d => d.Students)
                .Include(d => d.Instructors)
                .FirstOrDefault(d => d.deptId == id);
        }
    }
}