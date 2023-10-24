using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using GoalTracker.Areas.Identity.Data;

namespace GoalTracker.Models;

public class Status 
{
    public Guid Id {get;set;}

    public string? Name {get;set;}    

    public ApplicationUser? CreatedBy { get; set; }

    [Display(Name = "Created")]
    [DataType(DataType.Date)]
    public DateTime CreatedDate { get; set; }

}