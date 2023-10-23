﻿// <auto-generated />
using System;
using GoalTracker.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GoalTracker.Migrations
{
    [DbContext(typeof(GoalTrackerContext))]
    partial class GoalTrackerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.12");

            modelBuilder.Entity("FileAttachment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ActivityEntryId")
                        .HasColumnType("TEXT");

                    b.Property<string>("FileExtension")
                        .HasColumnType("TEXT");

                    b.Property<string>("FileName")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("GoalId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("MilestoneId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ProjectId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("RoadmapId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TrackingRecordId")
                        .HasColumnType("TEXT");

                    b.Property<string>("UploadedById")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UploadedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ActivityEntryId");

                    b.HasIndex("GoalId");

                    b.HasIndex("MilestoneId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("RoadmapId");

                    b.HasIndex("UploadedById");

                    b.ToTable("FileAttachment");
                });

            modelBuilder.Entity("GoalTracker.Models.ActivityEntry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("AssigneeId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Category")
                        .HasColumnType("TEXT");

                    b.Property<string>("Color")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Completed")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("CompletedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedById")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Favorited")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Icon")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("MilestoneId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("PriorityId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ReviewerId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartedDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("StatusId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TargetDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AssigneeId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("MilestoneId");

                    b.HasIndex("PriorityId");

                    b.HasIndex("ReviewerId");

                    b.HasIndex("StatusId");

                    b.ToTable("ActivityEntry");
                });

            modelBuilder.Entity("GoalTracker.Models.Goal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("AssigneeId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Category")
                        .HasColumnType("TEXT");

                    b.Property<string>("Color")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Completed")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("CompletedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedById")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Favorited")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Icon")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("PriorityId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ProjectId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ReviewerId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("RoadmapId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartedDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("StatusId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TargetDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AssigneeId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("PriorityId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("ReviewerId");

                    b.HasIndex("RoadmapId");

                    b.HasIndex("StatusId");

                    b.ToTable("Goal");
                });

            modelBuilder.Entity("GoalTracker.Models.Milestone", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("AssigneeId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Category")
                        .HasColumnType("TEXT");

                    b.Property<string>("Color")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Completed")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("CompletedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedById")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Favorited")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("GoalId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Icon")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("PriorityId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ReviewerId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartedDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("StatusId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TargetDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AssigneeId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("GoalId");

                    b.HasIndex("PriorityId");

                    b.HasIndex("ReviewerId");

                    b.HasIndex("StatusId");

                    b.ToTable("Milestone");
                });

            modelBuilder.Entity("Link", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ActivityEntryId")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedById")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("GoalId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("MilestoneId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ProjectId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("RoadmapId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ActivityEntryId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("GoalId");

                    b.HasIndex("MilestoneId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("RoadmapId");

                    b.ToTable("Link");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Priority", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedById")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PriorityInt")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.ToTable("Priority");
                });

            modelBuilder.Entity("Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("AssigneeId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Category")
                        .HasColumnType("TEXT");

                    b.Property<string>("Color")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Completed")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("CompletedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedById")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Favorited")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Icon")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("PriorityId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ReviewerId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartedDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("StatusId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TargetDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AssigneeId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("PriorityId");

                    b.HasIndex("ReviewerId");

                    b.HasIndex("StatusId");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("Roadmap", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("AssigneeId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Category")
                        .HasColumnType("TEXT");

                    b.Property<string>("Color")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Completed")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("CompletedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedById")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Favorited")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Icon")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("PriorityId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ProjectId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ReviewerId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartedDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("StatusId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TargetDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AssigneeId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("PriorityId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("ReviewerId");

                    b.HasIndex("StatusId");

                    b.ToTable("Roadmap");
                });

            modelBuilder.Entity("Status", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedById")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ActivityEntryId")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedById")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("GoalId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("MilestoneId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ProjectId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("RoadmapId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ActivityEntryId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("GoalId");

                    b.HasIndex("MilestoneId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("RoadmapId");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("FileAttachment", b =>
                {
                    b.HasOne("GoalTracker.Models.ActivityEntry", null)
                        .WithMany("FileAttachments")
                        .HasForeignKey("ActivityEntryId");

                    b.HasOne("GoalTracker.Models.Goal", null)
                        .WithMany("FileAttachments")
                        .HasForeignKey("GoalId");

                    b.HasOne("GoalTracker.Models.Milestone", null)
                        .WithMany("FileAttachments")
                        .HasForeignKey("MilestoneId");

                    b.HasOne("Project", null)
                        .WithMany("FileAttachments")
                        .HasForeignKey("ProjectId");

                    b.HasOne("Roadmap", null)
                        .WithMany("FileAttachments")
                        .HasForeignKey("RoadmapId");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "UploadedBy")
                        .WithMany()
                        .HasForeignKey("UploadedById");

                    b.Navigation("UploadedBy");
                });

            modelBuilder.Entity("GoalTracker.Models.ActivityEntry", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Assignee")
                        .WithMany()
                        .HasForeignKey("AssigneeId");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("GoalTracker.Models.Milestone", "Milestone")
                        .WithMany("Activities")
                        .HasForeignKey("MilestoneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Priority", "Priority")
                        .WithMany()
                        .HasForeignKey("PriorityId");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Reviewer")
                        .WithMany()
                        .HasForeignKey("ReviewerId");

                    b.HasOne("Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.Navigation("Assignee");

                    b.Navigation("CreatedBy");

                    b.Navigation("Milestone");

                    b.Navigation("Priority");

                    b.Navigation("Reviewer");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("GoalTracker.Models.Goal", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Assignee")
                        .WithMany()
                        .HasForeignKey("AssigneeId");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("Priority", "Priority")
                        .WithMany()
                        .HasForeignKey("PriorityId");

                    b.HasOne("Project", null)
                        .WithMany("Goals")
                        .HasForeignKey("ProjectId");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Reviewer")
                        .WithMany()
                        .HasForeignKey("ReviewerId");

                    b.HasOne("Roadmap", null)
                        .WithMany("Goals")
                        .HasForeignKey("RoadmapId");

                    b.HasOne("Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.Navigation("Assignee");

                    b.Navigation("CreatedBy");

                    b.Navigation("Priority");

                    b.Navigation("Reviewer");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("GoalTracker.Models.Milestone", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Assignee")
                        .WithMany()
                        .HasForeignKey("AssigneeId");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("GoalTracker.Models.Goal", "Goal")
                        .WithMany("Milestones")
                        .HasForeignKey("GoalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Priority", "Priority")
                        .WithMany()
                        .HasForeignKey("PriorityId");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Reviewer")
                        .WithMany()
                        .HasForeignKey("ReviewerId");

                    b.HasOne("Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.Navigation("Assignee");

                    b.Navigation("CreatedBy");

                    b.Navigation("Goal");

                    b.Navigation("Priority");

                    b.Navigation("Reviewer");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Link", b =>
                {
                    b.HasOne("GoalTracker.Models.ActivityEntry", null)
                        .WithMany("Links")
                        .HasForeignKey("ActivityEntryId");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("GoalTracker.Models.Goal", null)
                        .WithMany("Links")
                        .HasForeignKey("GoalId");

                    b.HasOne("GoalTracker.Models.Milestone", null)
                        .WithMany("Links")
                        .HasForeignKey("MilestoneId");

                    b.HasOne("Project", null)
                        .WithMany("Links")
                        .HasForeignKey("ProjectId");

                    b.HasOne("Roadmap", null)
                        .WithMany("Links")
                        .HasForeignKey("RoadmapId");

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Priority", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("Project", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Assignee")
                        .WithMany()
                        .HasForeignKey("AssigneeId");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("Priority", "Priority")
                        .WithMany()
                        .HasForeignKey("PriorityId");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Reviewer")
                        .WithMany()
                        .HasForeignKey("ReviewerId");

                    b.HasOne("Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.Navigation("Assignee");

                    b.Navigation("CreatedBy");

                    b.Navigation("Priority");

                    b.Navigation("Reviewer");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Roadmap", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Assignee")
                        .WithMany()
                        .HasForeignKey("AssigneeId");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("Priority", "Priority")
                        .WithMany()
                        .HasForeignKey("PriorityId");

                    b.HasOne("Project", null)
                        .WithMany("Roadmaps")
                        .HasForeignKey("ProjectId");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Reviewer")
                        .WithMany()
                        .HasForeignKey("ReviewerId");

                    b.HasOne("Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.Navigation("Assignee");

                    b.Navigation("CreatedBy");

                    b.Navigation("Priority");

                    b.Navigation("Reviewer");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Status", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("Tag", b =>
                {
                    b.HasOne("GoalTracker.Models.ActivityEntry", null)
                        .WithMany("Tags")
                        .HasForeignKey("ActivityEntryId");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("GoalTracker.Models.Goal", null)
                        .WithMany("Tags")
                        .HasForeignKey("GoalId");

                    b.HasOne("GoalTracker.Models.Milestone", null)
                        .WithMany("Tags")
                        .HasForeignKey("MilestoneId");

                    b.HasOne("Project", null)
                        .WithMany("Tags")
                        .HasForeignKey("ProjectId");

                    b.HasOne("Roadmap", null)
                        .WithMany("Tags")
                        .HasForeignKey("RoadmapId");

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("GoalTracker.Models.ActivityEntry", b =>
                {
                    b.Navigation("FileAttachments");

                    b.Navigation("Links");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("GoalTracker.Models.Goal", b =>
                {
                    b.Navigation("FileAttachments");

                    b.Navigation("Links");

                    b.Navigation("Milestones");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("GoalTracker.Models.Milestone", b =>
                {
                    b.Navigation("Activities");

                    b.Navigation("FileAttachments");

                    b.Navigation("Links");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("Project", b =>
                {
                    b.Navigation("FileAttachments");

                    b.Navigation("Goals");

                    b.Navigation("Links");

                    b.Navigation("Roadmaps");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("Roadmap", b =>
                {
                    b.Navigation("FileAttachments");

                    b.Navigation("Goals");

                    b.Navigation("Links");

                    b.Navigation("Tags");
                });
#pragma warning restore 612, 618
        }
    }
}
