using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoalTracker.Models;

public class Subscription 
{
    public Guid Id { get; set; }
    
    public string? Tier { get; set; }

    public string? Name { get; set; }

    public string? Price { get; set; }

    public string? Details { get; set; }

    public string? BillingFrequency { get; set; }
}
