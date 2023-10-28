using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoalTracker.Models;

public class Settings : TrackingRecord
{
    public string? Name { get; set; }

    public VizType? Type { get; set; }

    public string? JSONData { get; set; }
}
