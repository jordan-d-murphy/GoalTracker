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
    }
}
