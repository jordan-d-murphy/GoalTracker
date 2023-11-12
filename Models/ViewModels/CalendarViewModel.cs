using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace GoalTracker.Models;

public class CalendarViewModel
{
    
    public List<Project>? Projects { get; set; }

    public List<Roadmap>? RoadMaps { get; set; }

    public List<Goal>? Goals { get; set; }

    public List<Milestone>? Milestones { get; set; }

    public List<ActivityEntry>? Activities { get; set; }

}