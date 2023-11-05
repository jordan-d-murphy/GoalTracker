using GoalTracker.Areas.Identity.Data;
using GoalTracker.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGeneration.CommandLine;

namespace GoalTracker.Models;

public class DashIndexViewModel
{
    public Dash? Dashboard { get; set; }

    public ApplicationUser? CreatedUser { get; set; }

}
