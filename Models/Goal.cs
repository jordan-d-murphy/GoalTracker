using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using GoalTracker.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using SQLitePCL;

namespace GoalTracker.Models;

public class Goal : TrackingRecord
{
    public List<Milestone>? Milestones { get; set; }

    [NotMapped]
    [Display(Name = "Color Suggestions")]
    public List<SelectListItem>? ColorSuggestions { get; set; }

}