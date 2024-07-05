using Microsoft.EntityFrameworkCore;
using PlanningAPI.Abstract;
using PlanningAPI.Models;

namespace PlanningAPI.Repository
{
    public class WorkerPositionRepository : IWorkerPositionRepository
    {
        private readonly PlanningDbContext _dbContext;

        public WorkerPositionRepository(PlanningDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Workerposition?> GetById(int id)
        {
            return await _dbContext.Workerpositions.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
