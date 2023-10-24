using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using GoalTracker.Areas.Identity.Data;

namespace GoalTracker.Models;

public class FileAttachment 
{
    public Guid Id {get;set;}

    public Guid TrackingRecordId {get;set;}

    public string? FileName {get;set;}

    public string? FileExtension {get;set;}

    public string? Url {get;set;}

    public ApplicationUser? UploadedBy { get; set; }

    [Display(Name = "Uploaded")]
    [DataType(DataType.Date)]
    public DateTime UploadedDate { get; set; }

}