using System;
using System.Collections.Generic;

namespace PlanningAPI.Models;

public partial class Salary
{
    public int Id { get; set; }

    public decimal? Salary1 { get; set; }

    public virtual Workerposition? Workerposition { get; set; }
}
