using PlanningAPI.Models;

namespace PlanningAPI.Abstract
{
    public interface IWorkerPositionRepository
    {
        Task<Workerposition?> GetById(int id);
    }
}