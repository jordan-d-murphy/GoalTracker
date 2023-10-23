using GoalTracker.Models;

public class Project : TrackingRecord
{
    public List<Roadmap>? Roadmaps { get; set; }

    public List<Goal>? Goals { get; set; }
    
}