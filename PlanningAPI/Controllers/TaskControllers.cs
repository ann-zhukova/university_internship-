using Microsoft.AspNetCore.Mvc;
using PlanningAPI.Abstract;
using PlanningAPI.Contract;

namespace PlanningAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskControllers: ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TaskControllers(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskResponse>>> GetProjects()
        {
            var tasks = await _taskRepository.GetWithWorkers();
            var response = tasks.Select(
                t => new TaskResponse(
                    t.Id, 
                    t.Name, 
                    t.Description, 
                    t.StartDate, 
                    t.EndDate,
                    t.Status, 
                    t.DependsontaskNavigation?.Name, 
                    t.ProjectNavigation?.Name, 
                    t.Workers?.Select(w => w.Name).ToList()
                    )
                );
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> CreateTask([FromForm]TaskRequest taskRequest)
        {
            try
            {
                await _taskRepository.Create(taskRequest);
                return Ok();
            }
            catch (Exception ex)
            { 
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateTask(int id, [FromForm] TaskRequest taskRequest)
        {
            try
            {
                await _taskRepository.Update(id, taskRequest);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteTask(int id)
        {
            try
            {
                await _taskRepository.Delete( id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
 
    }
}
