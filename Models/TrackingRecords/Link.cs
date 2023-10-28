using System.ComponentModel.DataAnnotations;
using System.Security.Policy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using GoalTracker.Areas.Identity.Data;

namespace GoalTracker.Models;

public class Link : TrackingRecord
{
    [Display(Name = "Display Name")]
    public string? DisplayName {get;set;}

    public string? Url {get;set;}
    
}