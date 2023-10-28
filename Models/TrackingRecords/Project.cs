using GoalTracker.Models;

namespace GoalTracker.Models;

public class Project : TrackingRecord
{
    public Team? Team { get; set; }
}