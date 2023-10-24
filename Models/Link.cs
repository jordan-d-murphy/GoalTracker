using System.ComponentModel.DataAnnotations;
using System.Security.Policy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using GoalTracker.Areas.Identity.Data;

namespace GoalTracker.Models;

public class Link
{
    public Guid Id {get;set;}

    public string? Title {get;set;}

    public string? Url {get;set;}

    public ApplicationUser? CreatedBy { get; set; }

    [Display(Name = "Created")]
    [DataType(DataType.Date)]
    public DateTime CreatedDate { get; set; }
    
}