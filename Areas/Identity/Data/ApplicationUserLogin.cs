using Microsoft.AspNetCore.Identity;

namespace GoalTracker.Areas.Identity.Data;

public class ApplicationUserLogin : IdentityUserLogin<Guid>
{
    public virtual ApplicationUser? User { get; set; }
}