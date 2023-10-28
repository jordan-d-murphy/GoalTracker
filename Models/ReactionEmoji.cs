using System.Security.Policy;
using GoalTracker.Areas.Identity.Data;
using GoalTracker.Models;

namespace GoalTracker.Models;

public class ReactionEmoji
{
    public Guid Id { get; set; }

    public string? Emoji { get; set; }

    public ApplicationUser? CreatedBy { get; set; }
}