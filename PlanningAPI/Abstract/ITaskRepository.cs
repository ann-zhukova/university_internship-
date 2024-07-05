namespace PlanningAPI.Abstract
{
    public interface ITaskRepository
    {
        Task Create(int id, string name, string description, DateOnly startDate, DateOnly endDate, bool status, int dependsontask, int project);
        Task<List<Models.Task>> Get();
        Task<Models.Task?> GetById(int id);
        Task<List<Models.Task>> GetWithWorkers();
    }
}