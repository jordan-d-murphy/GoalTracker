using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace GoalTracker.Models;

public class Status 
{
    public Guid Id {get;set;}

    public string? Name {get;set;}    

    public IdentityUser? CreatedBy { get; set; }

    [Display(Name = "Created")]
    [DataType(DataType.Date)]
    public DateTime CreatedDate { get; set; }

}