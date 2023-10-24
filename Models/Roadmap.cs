using GoalTracker.Models;

namespace GoalTracker.Models;

public class Roadmap : TrackingRecord
{
    public List<Goal>? Goals { get; set; }
}