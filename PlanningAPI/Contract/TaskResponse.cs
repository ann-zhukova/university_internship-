namespace PlanningAPI.Contract
{
    public record TaskResponse
    (
       int id,
       string name, 
       string? description, 
       DateOnly? startDate, 
       DateOnly? endDate, 
       bool? status, 
       TaskDependsResponse? dependsontask, 
       TaskProjectResponse? project, 
       List<TaskWorkerResponse>? workers
    );
}
