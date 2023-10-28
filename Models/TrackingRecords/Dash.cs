using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoalTracker.Models;

public class Dash : TrackingRecord
{
    public string? Name { get; set; }

    public List<DashViz>? Vizualizations { get; set; }
}
