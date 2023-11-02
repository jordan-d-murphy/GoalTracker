using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GoalTracker.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using GoalTracker.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace GoalTracker.Data
{
    public class GoalTrackerContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid, 
        ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>
    {
        public GoalTrackerContext(DbContextOptions<GoalTrackerContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>(b =>
            {
                b.HasMany(e => e.Claims)
                    .WithOne()
                    .HasForeignKey(uc => uc.UserId)
                    .IsRequired();

                b.HasMany(e => e.Logins)
                    .WithOne()
                    .HasForeignKey(ul => ul.UserId)
                    .IsRequired();

                b.HasMany(e => e.Tokens)
                    .WithOne()
                    .HasForeignKey(ut => ut.UserId)
                    .IsRequired();

                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.User)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            builder.Entity<ApplicationRole>(b =>
            {
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.Role)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                b.HasMany(e => e.RoleClaims)
                    .WithOne(e => e.Role)
                    .HasForeignKey(rc => rc.RoleId)
                    .IsRequired();
            });
        }

        public DbSet<GoalTracker.Models.Goal> Goal { get; set; } = default!;

        public DbSet<GoalTracker.Models.Milestone> Milestone { get; set; } = default!;

        public DbSet<GoalTracker.Models.ActivityEntry> ActivityEntry { get; set; } = default!;

        public DbSet<FileAttachment> FileAttachment { get; set; } = default!;

        public DbSet<Link> Link { get; set; } = default!;

        public DbSet<RecordPriority> RecordPriority { get; set; } = default!;

        public DbSet<Project> Project { get; set; } = default!;

        public DbSet<Roadmap> Roadmap { get; set; } = default!;

        public DbSet<RecordStatus> RecordStatus { get; set; } = default!;

        public DbSet<Tag> Tag { get; set; } = default!;

        public DbSet<GoalTracker.Models.Billing> Billing { get; set; } = default!;

        public DbSet<GoalTracker.Models.Subscription> Subscription { get; set; } = default!;

        public DbSet<GoalTracker.Models.MetricType> MetricType { get; set; } = default!;

        public DbSet<GoalTracker.Models.VizType> VizType { get; set; } = default!;

        public DbSet<GoalTracker.Models.Dash> Dash { get; set; } = default!;

        public DbSet<GoalTracker.Models.DashViz> DashViz { get; set; } = default!;

        public DbSet<GoalTracker.Models.History> History { get; set; } = default!;

        public DbSet<GoalTracker.Models.Metric> Metric { get; set; } = default!;

        public DbSet<GoalTracker.Models.Note> Note { get; set; } = default!;

        public DbSet<GoalTracker.Models.Report> Report { get; set; } = default!;

        public DbSet<GoalTracker.Models.Settings> Settings { get; set; } = default!;

        public DbSet<GoalTracker.Models.SupportRequest> SupportRequest { get; set; } = default!;

        public DbSet<GoalTracker.Models.Team> Team { get; set; } = default!;

        public DbSet<GoalTracker.Models.Calendar> Calendar { get; set; } = default!;

        public DbSet<GoalTracker.Models.Template> Template { get; set; } = default!;

        public DbSet<GoalTracker.Models.Kai> Kai { get; set; } = default!;
    }
}
