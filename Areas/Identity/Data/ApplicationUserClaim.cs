using Microsoft.AspNetCore.Identity;

namespace GoalTracker.Areas.Identity.Data;

public class ApplicationUserClaim : IdentityUserClaim<Guid>
{
    public virtual ApplicationUser? User { get; set; }
}