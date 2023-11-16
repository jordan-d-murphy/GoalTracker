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
                    Description = "Buy Murmurshan from Grandma in one year.",
                    CreatedDate = DateTime.Parse("2023-11-10"),
                    StartedDate = DateTime.Parse("2023-11-12"),
                    TargetDate = DateTime.Parse("2024-10-01"),
                    Completed = false,
                    Favorited = true,
                    Category = "Personal",
                    Color = "#a372ee"
                }
            );
            context.Goal.AddRange(
                new Goal
                {
                    Title = "Get a new Job",
                    Description = "Base: $175k, Remote",
                    CreatedDate = DateTime.Parse("2023-11-12"),
                    StartedDate = DateTime.Parse("2023-11-13"),
                    TargetDate = DateTime.Parse("2024-10-01"),
                    Completed = false,
                    Favorited = true,
                    Category = "Work",
                    Color = "#a372ee"
                }
            );
            context.Goal.AddRange(
                new Goal
                {
                    Title = "Buy a house on the Oregon Coast",
                    Description = "Save up $100k down payment.",
                    CreatedDate = DateTime.Parse("2023-10-12"),
                    StartedDate = DateTime.Parse("2023-10-12"),
                    TargetDate = DateTime.Parse("2025-05-21"),
                    Completed = false,
                    Favorited = true,
                    Category = "Personal",
                    Color = "#a372ee"
                }
            );



            context.Milestone.AddRange(
                new Milestone
                {
                    Title = "Launch Koala MVP",
                    Description = "Deploy main Portfolio project MVP.",
                    CreatedDate = DateTime.Parse("2023-10-12"),
                    StartedDate = DateTime.Parse("2023-10-12"),
                    TargetDate = DateTime.Parse("2023-12-31"),
                    Completed = false,
                    Favorited = true,
                    Category = "Personal",
                    Color = "#a372ee"
                }
            );
            context.Milestone.AddRange(
                new Milestone
                {
                    Title = "Launch MantaRay MVP",
                    Description = "Deploy second Portfolio project MVP.",
                    CreatedDate = DateTime.Parse("2023-11-20"),
                    StartedDate = DateTime.Parse("2023-11-21"),
                    TargetDate = DateTime.Parse("2023-12-31"),
                    Completed = false,
                    Favorited = true,
                    Category = "Personal",
                    Color = "#a372ee"
                }
            );




            context.ActivityEntry.AddRange(
                new ActivityEntry
                {
                    Title = "HackerRank",
                    Description = "Solve Python challenges.",
                    CreatedDate = DateTime.Parse("2023-11-15"),
                    CompletedDate = DateTime.Parse("2023-11-15"),                    
                    Completed = true,
                    Favorited = true,
                    Category = "Personal",
                    Color = "#a372ee"
                }
            );
            context.ActivityEntry.AddRange(
                new ActivityEntry
                {
                    Title = "Leet Code",
                    Description = "Solve C# challenges.",
                    CreatedDate = DateTime.Parse("2023-11-15"),
                    CompletedDate = DateTime.Parse("2023-11-15"),                    
                    Completed = true,
                    Favorited = true,
                    Category = "Personal",
                    Color = "#a372ee"
                }
            );





            context.VizType.AddRange(
                new VizType
                {                    
                    Title = "Bar Chart",
                    Description = "A bar chart provides a way of showing data values represented as vertical bars. It is sometimes used to show trend data, and the comparison of multiple data sets side by side.",                                        
                    Name = "Bar"
                }
            );
            context.VizType.AddRange(
                new VizType
                {
                    Title = "Line Chart",
                    Description = "A line chart is a way of plotting data points on a line. Often, it is used to show trend data, or the comparison of two data sets.",
                    Name = "Line"
                }
            );
            context.VizType.AddRange(
                new VizType
                {
                    Title = "Pie Chart",
                    Description = "Pie charts are divided into segments, the arc of each segment shows the proportional value of each piece of data. They are excellent at showing the relational proportions between data.",
                    Name = "Pie"
                }
            );
            context.VizType.AddRange(
                new VizType
                {
                    Title = "Polar Area Chart",
                    Description = "Polar area charts are similar to pie charts, but each segment has the same angle - the radius of the segment differs depending on the value. This type of chart is often useful when we want to show a comparison data similar to a pie chart, but also show a scale of values for context.",
                    Name = "Polar"
                }
            );
            context.VizType.AddRange(
                new VizType
                {
                    Title = "Radar Chart",
                    Description = "A radar chart is a way of showing multiple data points and the variation between them. They are often useful for comparing the points of two or more different data sets.",
                    Name = "Radar"
                }
            );

            context.SaveChanges();
        }
    }
}