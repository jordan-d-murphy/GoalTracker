using GoalTracker.Areas.Identity.Data;
using GoalTracker.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGeneration.CommandLine;

namespace GoalTracker.Models;

public class ActivityIndexViewModel
{
    public ActivityEntry? Activity { get; set; }

    public ApplicationUser? CreatedUser { get; set; }

}
