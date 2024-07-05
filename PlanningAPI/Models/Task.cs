using System;
using System.Collections.Generic;

namespace PlanningAPI.Models;

public partial class Task
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public bool? Status { get; set; }

    public int? Dependsontask { get; set; }

    public int? Project { get; set; }

    public virtual Task? DependsontaskNavigation { get; set; }

    public virtual ICollection<Task> InverseDependsontaskNavigation { get; set; } = new List<Task>();

    public virtual Project? ProjectNavigation { get; set; }

    public virtual ICollection<Worker> Workers { get; set; } = new List<Worker>();
}
