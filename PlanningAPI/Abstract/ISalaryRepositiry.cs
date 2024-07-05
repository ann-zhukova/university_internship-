using PlanningAPI.Models;

namespace PlanningAPI.Abstract
{
    public interface ISalaryRepositiry
    {
        Task<Salary?> GetById(int id);
    }
}