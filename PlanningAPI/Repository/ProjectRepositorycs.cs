using Microsoft.EntityFrameworkCore;
using PlanningAPI.Abstract;
using PlanningAPI.Contract;
using PlanningAPI.Models;

namespace PlanningAPI.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly PlanningDbContext _dbContext;

        public ProjectRepository(PlanningDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Project>> Get()
        {
            return await _dbContext.Projects.AsNoTracking().ToListAsync();
        }

        public async Task<List<Project>> GetWithTask()
        {
            return await _dbContext.Projects.AsNoTracking().Include(c => c.Tasks).ToListAsync();
        }

        public async Task<Project?> GetById(int id)
        {
            return await _dbContext.Projects.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async System.Threading.Tasks.Task Create(ProjectRequest projectRequest)
        {
            var project = new Project
            {
                Name = projectRequest.name,
                Status = projectRequest.status
            };
            await _dbContext.Projects.AddAsync(project);
            await _dbContext.SaveChangesAsync();
        }
        public async System.Threading.Tasks.Task Update(int id, ProjectRequest projectRequest)
        {
            await _dbContext.Projects.Where(p => p.Id == id).ExecuteUpdateAsync(
                s => s.
                SetProperty(p => p.Name, p => projectRequest.name).
                SetProperty(p => p.Status, p => projectRequest.status)
                );
        }
        public async System.Threading.Tasks.Task Delete(int id)
        {
            await _dbContext.Projects.Where(p => p.Id == id).ExecuteDeleteAsync();
        }
    }
}
