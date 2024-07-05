using PlanningAPI.Models;

namespace PlanningAPI.Abstract
{
    public interface IProjectRepository
    {
        System.Threading.Tasks.Task Create(int id, string name, bool status);
        Task<List<Project>> Get();
        Task<Project?> GetById(int id);
        Task<List<Project>> GetWithTask();
    }
}