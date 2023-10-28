using GoalTracker.Areas.Identity.Data;
using GoalTracker.Models;
using Microsoft.VisualStudio.Web.CodeGeneration.CommandLine;

namespace GoalTracker.Models;

public class AdminAssign
{
    public string? Role { get; set; }

    public required Guid UserId { get; set; }

    public required string UserEmail { get; set; }

}
