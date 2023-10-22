using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoalTracker.Models;

public class Milestone : TrackingRecord
{

    public Guid GoalId { get; set; }

    public Goal Goal { get; set; } = null!;

    public List<ActivityEntry>? Activities { get; set; }


}