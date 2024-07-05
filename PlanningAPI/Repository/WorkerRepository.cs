using Microsoft.EntityFrameworkCore;
using PlanningAPI.Abstract;
using PlanningAPI.Models;

namespace PlanningAPI.Repository
{
    public class WorkerRepository : IWorkerRepository
    {
        private readonly PlanningDbContext _dbContext;

        public WorkerRepository(PlanningDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Worker>> Get()
        {
            return await _dbContext.Workers.
                AsNoTracking().
                ToListAsync();
        }

        public async Task<List<Worker>> GetWithDepartmentsPositions()
        {
            return await _dbContext.Workers.
                AsNoTracking().
                Include(c => c.PositionNavigation).
                Include(c => c.DepartmentNavigation).
                ToListAsync();
        }

        public async Task<Worker?> GetById(int id)
        {
            return await _dbContext.Workers.
                AsNoTracking().
                FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
