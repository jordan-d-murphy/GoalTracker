using GoalTracker.Areas.Identity.Data;
using GoalTracker.Enums;

namespace GoalTracker.Models;

public class OnlinePresence
{    

    public OnlinePresence(ApplicationUser user, OnlinePresenceStatus status) 
    {
        UserId = user.Id.ToString();
        UserEmail = user.Email;
        Status = status.ToString();
        Timestamp = DateTime.Now;
    }

    public string UserId { get; }

    public string? UserEmail { get; }

    public string? Status { get; }

    public DateTime Timestamp { get; }

}
