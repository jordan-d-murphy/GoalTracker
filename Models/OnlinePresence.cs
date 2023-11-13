using GoalTracker.Areas.Identity.Data;
using GoalTracker.Enums;

namespace GoalTracker.Models;

public class OnlinePresence
{    

    public OnlinePresence(string userId, string status) 
    {
        UserId = userId;
        Status = status;
        Timestamp = DateTime.Now;
    }

    public string UserId { get; set; }

    public string Status { get; set; }

    public DateTime Timestamp { get; set; }

}
