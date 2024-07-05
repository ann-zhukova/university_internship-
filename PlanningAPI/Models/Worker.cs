using System;
using System.Collections.Generic;

namespace PlanningAPI.Models;

public partial class Worker
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Position { get; set; }

    public int? Department { get; set; }

    public virtual Department? DepartmentNavigation { get; set; }

    public virtual Workerposition? PositionNavigation { get; set; }

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
