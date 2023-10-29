using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace GoalTracker.Models;

public class MetricType
{
    public Guid Id { get; set; }
    
    public string? Name { get; set; }

}
