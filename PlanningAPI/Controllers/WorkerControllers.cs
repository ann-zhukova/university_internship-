using Microsoft.AspNetCore.Mvc;
using PlanningAPI.Abstract;
using PlanningAPI.Contract;
using PlanningAPI.Repository;

namespace PlanningAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkerControllers : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IWorkerRepository _workerRepository;

        public WorkerControllers(IDepartmentRepository departmentRepository, IWorkerRepository workerRepository)
        {
            _departmentRepository = departmentRepository;
            _workerRepository = workerRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProjectResponse>>> GetProjects()
        {
            var workers = await _workerRepository.GetWithDepartmentsPositions();
            var response = workers.Select(w => new WorkerResponse(w.Id, w.Name, w.PositionNavigation.Name, w.DepartmentNavigation.Name));
            return Ok(response);
        }
    }
}
