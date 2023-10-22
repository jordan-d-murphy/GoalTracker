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
    public Guid? ProjectId { get; set; }

    public Guid? RoadmapId { get; set; }

    public List<Milestone>? Milestones { get; set; }

}