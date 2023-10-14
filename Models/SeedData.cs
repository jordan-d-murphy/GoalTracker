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
                    TargetDate = DateTime.Parse("2024-10-13"),
                    CompletedDate = DateTime.Parse("2024-10-13"),
                    Category = "Personal"
                },
                new Goal
                {
                    Title = "Get a New Job",
                    Description = "Get a remote job with a $160k minimum base salary",
                    CreatedDate = DateTime.Parse("2023-10-13"),
                    TargetDate = DateTime.Parse("2024-10-13"),
                    CompletedDate = DateTime.Parse("2024-10-13"),
                    Category = "Work"
                },
                new Goal
                {
                    Title = "Move to the Oregon coast",
                    Description = "Find a better place to live that feels like home",
                    CreatedDate = DateTime.Parse("2023-10-13"),
                    TargetDate = DateTime.Parse("2024-10-13"),
                    CompletedDate = DateTime.Parse("2024-10-13"),
                    Category = "Personal"
                },
                new Goal
                {
                    Title = "Buy a Porsche 911 Turbo S",
                    Description = "Dream car | Green // Cognac",
                    CreatedDate = DateTime.Parse("2023-10-13"),
                    TargetDate = DateTime.Parse("2024-10-13"),
                    CompletedDate = DateTime.Parse("2024-10-13"),
                    Category = "Hobbies"
                },
                new Goal
                {
                    Title = "Get a Rolex GMT Master II Sprite",
                    Description = "Matching colors with my 911",
                    CreatedDate = DateTime.Parse("2023-10-13"),
                    TargetDate = DateTime.Parse("2024-10-13"),
                    CompletedDate = DateTime.Parse("2024-10-13"),
                    Category = "Hobbies"
                },
                new Goal
                {
                    Title = "Get a Cocker Spaniel",
                    Description = "Walks on the beach // Road Dog // Cuddle Buddy // BFF",
                    CreatedDate = DateTime.Parse("2023-10-13"),
                    TargetDate = DateTime.Parse("2024-10-13"),
                    CompletedDate = DateTime.Parse("2024-10-13"),
                    Category = "Personal"
                },
                new Goal
                {
                    Title = "Pay off all my debt",
                    Description = "Fix my credit",
                    CreatedDate = DateTime.Parse("2023-10-13"),
                    TargetDate = DateTime.Parse("2024-10-13"),
                    CompletedDate = DateTime.Parse("2024-10-13"),
                    Category = "Finance"
                },
                new Goal
                {
                    Title = "Run a Marathon",
                    Description = "",
                    CreatedDate = DateTime.Parse("2023-10-13"),
                    TargetDate = DateTime.Parse("2024-10-13"),
                    CompletedDate = DateTime.Parse("2024-10-13"),
                    Category = "Health"
                }
            );

            context.SaveChanges();
        }
    }
}