using System;
using System.Collections.Generic;

namespace PlanningAPI.Models;

public partial class Department
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Worker> Workers { get; set; } = new List<Worker>();
}
