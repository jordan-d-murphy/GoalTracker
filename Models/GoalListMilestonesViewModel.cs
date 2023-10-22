using GoalTracker.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using SQLitePCL;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace GoalTracker.Models;

public class GoalListMilestonesViewModel
{

    public List<Goal>? Goals { get; set; }

    public List<Milestone>? Milestones { get; set; }

    public List<ActivityEntry>? ActivityEntries { get; set; }    
    
    [Display(Name = "Suggestions")]
    public List<SelectListItem>? ColorSuggestions { get; set; }

}