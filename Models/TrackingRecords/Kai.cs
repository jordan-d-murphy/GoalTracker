using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace GoalTracker.Models;

public class Kai
{
    public Guid Id { get; set; }

    public string? Model { get; set; }

    public string? Prompt { get; set; } 

    public string? Response { get; set; } 

}
