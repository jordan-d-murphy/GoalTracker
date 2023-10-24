using Microsoft.AspNetCore.Identity;

namespace GoalTracker.Areas.Identity.Data;

public class ApplicationUserToken : IdentityUserToken<Guid> 
{
    public virtual ApplicationUser? User { get; set; }
}