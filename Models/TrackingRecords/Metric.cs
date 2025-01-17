using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoalTracker.Models;

public class Metric : TrackingRecord
{
    public string? Name { get; set; }

    public MetricType? Type { get; set; }

    public string? JSONData { get; set; }
}
