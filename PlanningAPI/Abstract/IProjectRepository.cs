using PlanningAPI.Contract;
using PlanningAPI.Models;

namespace PlanningAPI.Abstract
{
    public interface IProjectRepository
    {
        System.Threading.Tasks.Task Create(ProjectRequest projectRequest);
        Task<List<Project>> Get();
        Task<Project?> GetById(int id);
        Task<List<Project>> GetWithTask();
        System.Threading.Tasks.Task Delete(int id);

        System.Threading.Tasks.Task Update(int id, ProjectRequest projectRequest);
    }
}