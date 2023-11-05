using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace GoalTracker.Models;

public class MetricType : TrackingRecord
{    
    public string? Name { get; set; }
    
    public string? JSONData { get; set; }

}
