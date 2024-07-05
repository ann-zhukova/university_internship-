using System;
using System.Collections.Generic;

namespace PlanningAPI.Models;

public partial class Workerposition
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Salary { get; set; }

    public virtual Salary? SalaryNavigation { get; set; }

    public virtual ICollection<Worker> Workers { get; set; } = new List<Worker>();
}
