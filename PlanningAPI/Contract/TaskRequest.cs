namespace PlanningAPI.Contract
{
    public record TaskRequest
    (
       string name,
       string? description,
       string? startDate, 
       string? endDate,
       bool? status,
       int? dependsontask,
       int? project,
       List<int>? workers
    );
}
