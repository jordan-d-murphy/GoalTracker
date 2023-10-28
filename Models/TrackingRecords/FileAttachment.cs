using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using GoalTracker.Areas.Identity.Data;

namespace GoalTracker.Models;

public class FileAttachment : TrackingRecord
{
    public string? FileName {get;set;}

    public string? FileExtension {get;set;}

    public string? Url {get;set;}

}