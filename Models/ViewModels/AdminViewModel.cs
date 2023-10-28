using GoalTracker.Areas.Identity.Data;
using GoalTracker.Models;
using Microsoft.VisualStudio.Web.CodeGeneration.CommandLine;

namespace GoalTracker.Models;

public class AdminViewModel
{

    public required List<ApplicationUserViewModel> AllUsers { get; set; }

    public required List<GoalTracker.Areas.Identity.Data.ApplicationRole> AllRoles { get; set; }

    public string? AdminVMMessage { get; set; }

    public string? AdminVMMessageType { get; set; }
}
