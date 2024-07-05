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
       string? dependsontask, 
       string? project, 
       List<string>? workers
    );
}
