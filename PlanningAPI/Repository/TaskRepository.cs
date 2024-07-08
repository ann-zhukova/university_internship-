using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PlanningAPI.Abstract;
using PlanningAPI.Contract;
using PlanningAPI.Models;
using System.Globalization;

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
            return await _dbContext.Tasks.AsNoTracking().Include(c => c.Workers).Include(c => c.DependsontaskNavigation).Include(c=>c.ProjectNavigation).ToListAsync();
        }

        public async Task<PlanningAPI.Models.Task?> GetById(int id)
        {
            return await _dbContext.Tasks.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }
        public async System.Threading.Tasks.Task Create(TaskRequest taskRequest)
        {
            var workers = await  _dbContext.Workers.Where(w => taskRequest.workers.Contains(w.Id)).ToListAsync();
            var task = new PlanningAPI.Models.Task
            {
                Name = taskRequest.name,
                Description = taskRequest.description,
                Status = taskRequest.status,
                StartDate = DateOnly.ParseExact(taskRequest.startDate, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                EndDate = DateOnly.ParseExact(taskRequest.endDate, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                Project = taskRequest.project,
                Dependsontask = taskRequest.dependsontask,
                Workers = workers
            };
            await _dbContext.Tasks.AddAsync(task);
            await _dbContext.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task Update(int id, TaskRequest taskRequest)
        {
            var workers = await _dbContext.Workers.Where(w => taskRequest.workers.Contains(w.Id)).ToListAsync();
            await _dbContext.Tasks.Where(t => t.Id == id).ExecuteUpdateAsync(
                s => s.
                SetProperty(t => t.Name, t => taskRequest.name).
                SetProperty(t => t.Description, t => taskRequest.description).
                SetProperty(t => t.StartDate, t => DateOnly.ParseExact(taskRequest.startDate, "yyyy-MM-dd")).
                SetProperty(t => t.EndDate, t => DateOnly.ParseExact(taskRequest.endDate, "yyyy-MM-dd")).
                SetProperty(t => t.Status, t => taskRequest.status).
                SetProperty(t => t.Dependsontask, t => taskRequest.dependsontask).
                SetProperty(t => t.Project, t => taskRequest.project).
                SetProperty(t => t.Workers, t => workers)
                );
            await _dbContext.SaveChangesAsync();
        }
        public async System.Threading.Tasks.Task Delete(int id)
        {

            await _dbContext.Tasks.Where(t => t.Id == id).ExecuteDeleteAsync();
        }
    }
}
