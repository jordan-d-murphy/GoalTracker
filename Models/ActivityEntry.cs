using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoalTracker.Models;

public class ActivityEntry : TrackingRecord
{
    public Guid MilestoneId { get; set; }

    public Milestone Milestone { get; set; } = null!;

}
