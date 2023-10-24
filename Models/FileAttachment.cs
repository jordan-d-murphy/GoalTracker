using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace GoalTracker.Models;

public class FileAttachment 
{
    public Guid Id {get;set;}

    public Guid TrackingRecordId {get;set;}

    public string? FileName {get;set;}

    public string? FileExtension {get;set;}

    public string? Url {get;set;}

    public IdentityUser? UploadedBy { get; set; }

    [Display(Name = "Uploaded")]
    [DataType(DataType.Date)]
    public DateTime UploadedDate { get; set; }

}