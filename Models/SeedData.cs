using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GoalTracker.Data;
using System;
using System.Linq;
using System.Net.Http.Headers;

namespace GoalTracker.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new GoalTrackerContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<GoalTrackerContext>>()))
        {
            if (context.Goal.Any())
            {
                return;
            }

            context.Goal.AddRange(
                new Goal
                {
                    Title = "Buy Murmurshan",
                    Description = "Buy Murmurshan from Grandma in one year",
                    CreatedDate = DateTime.Parse("2023-10-13"),
                    StartedDate = DateTime.Parse("2023-10-13"),
                    TargetDate = DateTime.Parse("2024-10-13"),
                    Completed = false,
                    Favorited = true,
                    Category = "Personal",
                    Color = "#a372ee"
                }
            );

            context.SaveChanges();
        }
    }
}