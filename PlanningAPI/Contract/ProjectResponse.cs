namespace PlanningAPI.Contract
{
    public record ProjectResponse
    (
        int id,
        string? name, 
        bool? status
    );
}
