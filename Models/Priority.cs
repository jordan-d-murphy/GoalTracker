using System.ComponentModel.DataAnnotations;
using System.Security.Policy;
using Microsoft.AspNetCore.Identity;
using GoalTracker.Areas.Identity.Data;

namespace GoalTracker.Models;

public class Priority
{
    public Guid Id {get;set;}

    public string? Name {get;set;}

    public int? PriorityInt {get;set;}

    public ApplicationUser? CreatedBy { get; set; }

    [Display(Name = "Created")]
    [DataType(DataType.Date)]
    public DateTime CreatedDate { get; set; }
    
}