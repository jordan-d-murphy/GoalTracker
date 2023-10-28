using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using GoalTracker.Areas.Identity.Data;

namespace GoalTracker.Models;

public abstract class TrackingRecord
{
    public Guid Id { get; set; }

    public Guid? ParentId { get; set; }

    public TrackingRecord? ParentClass { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    [Display(Name = "Created")]
    [DataType(DataType.Date)]
    public DateTime CreatedDate { get; set; }

    [Display(Name = "Started")]
    [DataType(DataType.Date)]
    public DateTime StartedDate { get; set; }

    [Display(Name = "Target")]
    [DataType(DataType.Date)]
    public DateTime TargetDate { get; set; }

    [Display(Name = "Completed")]
    [DataType(DataType.Date)]
    public DateTime? CompletedDate { get; set; }

    public bool Completed { get; set; }

    public bool Favorited { get; set; }

    public string? Category { get; set; }

    public string? Icon { get; set; }

    public string? Color { get; set; }

    public string GetTextColor()
    {
        if (!String.IsNullOrEmpty(this.Color))
        {
            Color color = ColorTranslator.FromHtml(this.Color);
            var brightness = color.GetBrightness();
            if (brightness < 0.5)
            {
                return "#FFFFFF";
            }
        }
        return "#000000";
    }

    [NotMapped]
    [Display(Name = "Color Suggestions")]
    public List<SelectListItem>? ColorSuggestions { get; set; }

    public List<TrackingRecord>? Children { get; set; }

    public List<FileAttachment>? FileAttachments { get; set; }

    public List<ReactionEmoji>? ReactionEmojis { get; set; }

    public List<Link>? Links { get; set; }

    public List<Tag>? Tags { get; set; }

    public List<Note>? Notes { get; set; }

    public ApplicationUser? CreatedBy { get; set; }

    public ApplicationUser? Assignee { get; set; }

    public ApplicationUser? Reviewer { get; set; }

    public Status? Status { get; set; }

    public Priority? Priority { get; set; }

}