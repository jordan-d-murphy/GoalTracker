using GoalTracker.Areas.Identity.Data;

namespace GoalTracker.Models;

public class Notification
{
    public Guid Id { get; set; }

    public string? MessageBody { get; set; }

    public ApplicationUser? Sender { get; set; }

    public ApplicationUser? Receiver { get; set; }

    public DateTime? SentTimestamp { get; set; }

    public DateTime? DeliveredTimestamp { get; set; }

    public DateTime? ReadTimestamp { get; set; }

    public bool Read { get; set; } 

    public bool GeneratedByApplication { get; set; }    
}