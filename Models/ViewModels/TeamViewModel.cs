using GoalTracker.Areas.Identity.Data;
using GoalTracker.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGeneration.CommandLine;

namespace GoalTracker.Models;

public class TeamViewModel
{

    public required List<SelectListItem> AllUsers { get; set; }

    public IEnumerable<GoalTracker.Models.Team>? Teams { get; set; }

    public ApplicationUser? AddUser { get; set; }

    public Team? AddTeam { get; set; }

    public ApplicationUser? RemoveUser { get; set; }

    public Team? RemoveTeam { get; set; }

    public string? TeamVMMessage { get; set; }

    public string? TeamVMMessageType { get; set; }
}
