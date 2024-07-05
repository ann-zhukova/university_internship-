using PlanningAPI.Models;

namespace PlanningAPI.Abstract
{
    public interface IWorkerRepository
    {
        Task<List<Worker>> Get();
        Task<Worker?> GetById(int id);
        Task<List<Worker>> GetWithDepartmentsPositions();
    }
}