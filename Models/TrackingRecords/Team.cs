using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GoalTracker.Areas.Identity.Data;

namespace GoalTracker.Models;

public class Team : TrackingRecord
{
    [Display(Name = "Members")]
    public virtual List<ApplicationUser>? TeamMembers { get; set; }
}
