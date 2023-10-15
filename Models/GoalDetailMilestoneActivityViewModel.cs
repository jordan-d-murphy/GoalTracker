using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace GoalTracker.Models;

public class GoalDetailMilestoneActivityViewModel
{
    public Goal? Goal { get; set; }

    public List<Milestone>? Milestones { get; set; }

    public List<ActivityEntry>? Activities { get; set; }

}