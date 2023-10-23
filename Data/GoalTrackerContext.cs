using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GoalTracker.Models;

namespace GoalTracker.Data
{
    public class GoalTrackerContext : DbContext
    {
        public GoalTrackerContext (DbContextOptions<GoalTrackerContext> options)
            : base(options)
        {
        }

        public DbSet<GoalTracker.Models.Goal> Goal { get; set; } = default!;

        public DbSet<GoalTracker.Models.Milestone> Milestone { get; set; } = default!;

        public DbSet<GoalTracker.Models.ActivityEntry> ActivityEntry { get; set; } = default!;

        public DbSet<FileAttachment> FileAttachment { get; set; } = default!;

        public DbSet<Link> Link { get; set; } = default!;

        public DbSet<Priority> Priority { get; set; } = default!;

        public DbSet<Project> Project { get; set; } = default!;

        public DbSet<Roadmap> Roadmap { get; set; } = default!;

        public DbSet<Status> Status { get; set; } = default!;

        public DbSet<Tag> Tag { get; set; } = default!;
    }
}
