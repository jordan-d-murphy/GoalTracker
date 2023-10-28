
using GoalTracker.Areas.Identity.Data;

namespace GoalTracker.Models;

public class ApplicationUserViewModel
{
    public required ApplicationUser User { get; set; }

    public required List<string> UserRoles { get; set; }
}