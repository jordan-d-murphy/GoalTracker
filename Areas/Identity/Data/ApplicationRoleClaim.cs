using Microsoft.AspNetCore.Identity;

namespace GoalTracker.Areas.Identity.Data;

public class ApplicationRoleClaim : IdentityRoleClaim<Guid> 
{
    public virtual ApplicationRole? Role { get; set; }
}