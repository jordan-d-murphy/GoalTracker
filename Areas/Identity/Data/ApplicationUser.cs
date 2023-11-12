using Microsoft.AspNetCore.Identity;

namespace GoalTracker.Areas.Identity.Data;

public class ApplicationUser : IdentityUser<Guid>
{
    public virtual ICollection<ApplicationUserClaim>? Claims { get; set; }
    public virtual ICollection<ApplicationUserLogin>? Logins { get; set; }
    public virtual ICollection<ApplicationUserToken>? Tokens { get; set; }
    public virtual ICollection<ApplicationUserRole>? UserRoles { get; set; }

    [PersonalData]
    public string? CustomTag { get; set; }

    [PersonalData]
    public string? City { get; set; }

    [PersonalData]
    public string? State { get; set; }

    [PersonalData]
    public string? Zip { get; set; }

    [PersonalData]
    public string? DisplayName { get; set; }

    [PersonalData]
    public DateTime DOB { get; set; }

    public DateTime? OnlinePresenceIndicator { get; set; }

}
