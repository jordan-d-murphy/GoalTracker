using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoalTracker.Models;

public class ActivityEntry : TrackingRecord
{
    public Milestone Milestone {get;set;}

    public ActivityEntry() 
    {
        Milestone = new Milestone();
    }

    public ActivityEntry(Milestone milestone) 
    {
        Milestone = milestone;
    }

}
