using Microsoft.EntityFrameworkCore;
using PlanningAPI.Abstract;
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

        public async System.Threading.Tasks.Task Create(int id, string name, bool status)
        {
            var project = new Project
            {
                Id = id,
                Name = name,
                Status = status
            };
            await _dbContext.Projects.AddAsync(project);
            await _dbContext.SaveChangesAsync();
        }
    }
}
