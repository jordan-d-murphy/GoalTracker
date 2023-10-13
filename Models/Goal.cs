using System.ComponentModel.DataAnnotations;

namespace GoalTracker.Models;

public class Goal
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    [DataType(DataType.Date)]
    public DateTime CreatedDate { get; set; }

    [DataType(DataType.Date)]
    public DateTime TargetDate { get; set; }

    [DataType(DataType.Date)]
    public DateTime CompletedDate { get; set; }

    public string? Category { get; set; }




}