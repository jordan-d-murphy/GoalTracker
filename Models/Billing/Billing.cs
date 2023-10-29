using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GoalTracker.Areas.Identity.Data;
using Microsoft.AspNetCore.Components;

namespace GoalTracker.Models;

public class Billing
{   

    public Guid Id { get; set; }
    
    public ApplicationUser? User { get; set; }

    public Subscription? Subscription { get; set; }

    public DateTime? BillingDate { get; set; }

    public DateTime? DueDate { get; set; }

    public DateTime? PaidDate { get; set; }

    public bool Paid { get; set; }

}
