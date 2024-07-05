namespace PlanningAPI.Contract
{
    public record WorkerResponse
    (
        int id,
        string? name, 
        string? position,
        string? department
    );
}
