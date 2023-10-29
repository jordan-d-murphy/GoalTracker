using System.ComponentModel.DataAnnotations;
using System.Security.Policy;
using Microsoft.AspNetCore.Identity;
using GoalTracker.Areas.Identity.Data;

namespace GoalTracker.Models;

public class RecordPriority : TrackingRecord
{    
    public int? PriorityInt {get;set;}
   
}