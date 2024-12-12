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
            // Retrieve the workers based on the provided IDs in taskRequest
            List<Worker> workers;

            if (taskRequest.workers != null && taskRequest.workers.Any())
            {
                workers = await _dbContext.Workers
                    .Where(w => taskRequest.workers.Contains(w.Id))
                    .ToListAsync();
            }
            else
            {
                workers = new List<Worker>(); // Initialize as an empty list instead of null
            }

            // Find the task to update
            var taskToUpdate = await _dbContext.Tasks
                .Include(t => t.Workers) // Include the Workers collection
                .FirstOrDefaultAsync(t => t.Id == id);
    
            if (taskToUpdate == null)
            {
                throw new Exception("Task not found");
            }

            // Update the task properties
            taskToUpdate.Name = taskRequest.name;
            taskToUpdate.Description = taskRequest.description;
            taskToUpdate.StartDate = DateOnly.ParseExact(taskRequest.startDate, "yyyy-MM-dd");
            taskToUpdate.EndDate = DateOnly.ParseExact(taskRequest.endDate, "yyyy-MM-dd");
            taskToUpdate.Status = taskRequest.status;
            taskToUpdate.Dependsontask = taskRequest.dependsontask;
            taskToUpdate.Project = taskRequest.project;

            // Clear existing workers and add new ones
            taskToUpdate.Workers.Clear(); // Clear existing workers
            foreach (var worker in workers)
            {
                taskToUpdate.Workers.Add(worker); // Add each worker
            }
            // Save changes to the database
            await _dbContext.SaveChangesAsync();
        }
        public async System.Threading.Tasks.Task Delete(int id)
        {

            await _dbContext.Tasks.Where(t => t.Id == id).ExecuteDeleteAsync();
        }
    }
}
