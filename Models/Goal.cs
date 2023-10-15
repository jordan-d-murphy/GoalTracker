using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoalTracker.Models;

public class Goal : TrackingRecord
{
    public List<Milestone>? Milestones { get; set; }

}