using PlanningAPI.Models;

namespace PlanningAPI.Abstract
{
    public interface IDepartmentRepository
    {
        Task<List<Department>> Get();
        Task<Department?> GetById(int id);
        Task<List<Department>> GetWithWorker();
    }
}