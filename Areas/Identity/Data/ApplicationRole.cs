using System;
using Microsoft.AspNetCore.Identity;

namespace GoalTracker.Areas.Identity.Data;

public class ApplicationRole : IdentityRole<Guid>
{
    public virtual ICollection<ApplicationUserRole>? UserRoles { get; set; }

    public virtual ICollection<ApplicationRoleClaim>? RoleClaims { get; set; }

    public string? Description { get; set; }

}