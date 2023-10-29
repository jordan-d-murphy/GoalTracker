using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoalTracker.Models;

public class VizType
{
    public Guid Id { get; set; }
    
    public string? Name { get; set; }
}
