using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoalTracker.Models;

public class Milestone : TrackingRecord
{
    public Goal Goal {get;set;}
    public List<ActivityEntry>? Activities { get; set; }

    public Milestone() 
    {
        Goal = new Goal();
        Activities = new List<ActivityEntry>();
    }

    public Milestone(Goal goal) 
    {
        Goal = goal;
        Activities = new List<ActivityEntry>();
    }

}