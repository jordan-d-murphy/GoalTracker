using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace GoalTracker.Models;

public class GoalListMilestonesViewModel
{
    public List<Goal>? Goals { get; set; }

    public List<Milestone>? Milestones { get; set; }

}