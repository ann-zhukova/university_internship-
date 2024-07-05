using Microsoft.EntityFrameworkCore;
using PlanningAPI.Abstract;
using PlanningAPI.Models;

namespace PlanningAPI.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly PlanningDbContext _dbContext;

        public TaskRepository(PlanningDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<PlanningAPI.Models.Task>> Get()
        {
            return await _dbContext.Tasks.AsNoTracking().ToListAsync();
        }

        public async Task<List<PlanningAPI.Models.Task>> GetWithWorkers()
        {
            return await _dbContext.Tasks.AsNoTracking().Include(c => c.Workers).ToListAsync();
        }

        public async Task<PlanningAPI.Models.Task?> GetById(int id)
        {
            return await _dbContext.Tasks.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }
        public async System.Threading.Tasks.Task Create(int id, string name, string description, DateOnly startDate, DateOnly endDate, bool status, int dependsontask, int project)
        {
            var task = new PlanningAPI.Models.Task
            {
                Id = id,
                Name = name,
                Description = description,
                Status = status,
                StartDate = startDate,
                EndDate = endDate,
                Project = project,
                Dependsontask = dependsontask
            };
            await _dbContext.Tasks.AddAsync(task);
            await _dbContext.SaveChangesAsync();
        }
    }
}
