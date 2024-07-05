using Microsoft.EntityFrameworkCore;
using PlanningAPI.Abstract;
using PlanningAPI.Models;

namespace PlanningAPI.Repository
{
    public class SalaryRepositiry : ISalaryRepositiry
    {
        private readonly PlanningDbContext _dbContext;

        public SalaryRepositiry(PlanningDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Salary?> GetById(int id)
        {
            return await _dbContext.Salaries.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
