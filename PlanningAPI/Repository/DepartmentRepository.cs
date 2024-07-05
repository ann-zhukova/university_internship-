using Microsoft.EntityFrameworkCore;
using PlanningAPI.Abstract;
using PlanningAPI.Models;

namespace PlanningAPI.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly PlanningDbContext _dbContext;

        public DepartmentRepository(PlanningDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Department>> Get()
        {
            return await _dbContext.Departments.AsNoTracking().ToListAsync();
        }

        public async Task<List<Department>> GetWithWorker()
        {
            return await _dbContext.Departments.AsNoTracking().Include(c => c.Workers).ToListAsync();
        }

        public async Task<Department?> GetById(int id)
        {
            return await _dbContext.Departments.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
