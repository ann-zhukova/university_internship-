namespace PlanningAPI.Models;

public partial class Project
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public bool? Status { get; set; }

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
