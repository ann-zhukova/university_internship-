using Microsoft.AspNetCore.Mvc;
using PlanningAPI.Abstract;
using PlanningAPI.Contract;
using System.Linq;
using System.Runtime.CompilerServices;

namespace PlanningAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectControllers: ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IWorkerRepository _workerRepository;
        private readonly IProjectRepository _projectRepository;

        public ProjectControllers(IDepartmentRepository departmentRepository, IWorkerRepository workerRepository, IProjectRepository projectRepository)
        {
            _departmentRepository = departmentRepository;
            _workerRepository = workerRepository;
            _projectRepository = projectRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProjectResponse>>> GetProjects()
        {
            var projects = await _projectRepository.Get();
            var response = projects.Select(p => new ProjectResponse(p.Id, p.Name, p.Status));
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateProject([FromForm]ProjectRequest projectRequest)
        {
            try
            {
                await _projectRepository.Create(projectRequest);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateProject(int id, [FromForm] ProjectRequest projectRequest)
        {
            try
            {
                await _projectRepository.Update(id, projectRequest);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> UpdateProject(int id)
        {
            try
            {
                await _projectRepository.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
