using PlanningAPI.Contract;

namespace PlanningAPI.Abstract
{
    public interface ITaskRepository
    {
        Task Create(TaskRequest taskRequest);
        Task<List<Models.Task>> Get();
        Task<Models.Task?> GetById(int id);
        Task<List<Models.Task>> GetWithWorkers();
        Task Update(int id, TaskRequest taskRequest);
        Task Delete(int id);
    }
}