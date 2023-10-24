using System.ComponentModel.DataAnnotations;
using System.Security.Policy;
using Microsoft.AspNetCore.Identity;

namespace GoalTracker.Models;

public class Priority
{
    public Guid Id {get;set;}

    public string? Name {get;set;}

    public int? PriorityInt {get;set;}

    public IdentityUser? CreatedBy { get; set; }

    [Display(Name = "Created")]
    [DataType(DataType.Date)]
    public DateTime CreatedDate { get; set; }
    
}