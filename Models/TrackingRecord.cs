using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoalTracker.Models;

public abstract class TrackingRecord
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    [Display(Name = "Created")]
    [DataType(DataType.Date)]
    public DateTime CreatedDate { get; set; }

    [Display(Name = "Target")]
    [DataType(DataType.Date)]
    public DateTime TargetDate { get; set; }

    [Display(Name = "Completed")]
    [DataType(DataType.Date)]
    public DateTime? CompletedDate { get; set; }

    public bool Completed { get; set; }

    public string? Category { get; set; }

    public string? Icon { get; set; }

    public string? Color { get; set; }


}