using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoalTracker.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CustomTag = table.Column<string>(type: "TEXT", nullable: true),
                    DisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    DOB = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId1 = table.Column<Guid>(type: "TEXT", nullable: true),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    UserId1 = table.Column<Guid>(type: "TEXT", nullable: true),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RoleId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    UserId1 = table.Column<Guid>(type: "TEXT", nullable: true),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Priority",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    PriorityInt = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedById = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Priority", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Priority_IdentityUser_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "IdentityUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedById = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Status_IdentityUser_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "IdentityUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    StartedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TargetDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CompletedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Completed = table.Column<bool>(type: "INTEGER", nullable: false),
                    Favorited = table.Column<bool>(type: "INTEGER", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: true),
                    Icon = table.Column<string>(type: "TEXT", nullable: true),
                    Color = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedById = table.Column<string>(type: "TEXT", nullable: true),
                    AssigneeId = table.Column<string>(type: "TEXT", nullable: true),
                    ReviewerId = table.Column<string>(type: "TEXT", nullable: true),
                    StatusId = table.Column<Guid>(type: "TEXT", nullable: true),
                    PriorityId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_IdentityUser_AssigneeId",
                        column: x => x.AssigneeId,
                        principalTable: "IdentityUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Project_IdentityUser_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "IdentityUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Project_IdentityUser_ReviewerId",
                        column: x => x.ReviewerId,
                        principalTable: "IdentityUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Project_Priority_PriorityId",
                        column: x => x.PriorityId,
                        principalTable: "Priority",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Project_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Roadmap",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProjectId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    StartedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TargetDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CompletedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Completed = table.Column<bool>(type: "INTEGER", nullable: false),
                    Favorited = table.Column<bool>(type: "INTEGER", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: true),
                    Icon = table.Column<string>(type: "TEXT", nullable: true),
                    Color = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedById = table.Column<string>(type: "TEXT", nullable: true),
                    AssigneeId = table.Column<string>(type: "TEXT", nullable: true),
                    ReviewerId = table.Column<string>(type: "TEXT", nullable: true),
                    StatusId = table.Column<Guid>(type: "TEXT", nullable: true),
                    PriorityId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roadmap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roadmap_IdentityUser_AssigneeId",
                        column: x => x.AssigneeId,
                        principalTable: "IdentityUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Roadmap_IdentityUser_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "IdentityUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Roadmap_IdentityUser_ReviewerId",
                        column: x => x.ReviewerId,
                        principalTable: "IdentityUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Roadmap_Priority_PriorityId",
                        column: x => x.PriorityId,
                        principalTable: "Priority",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Roadmap_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Roadmap_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Goal",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProjectId = table.Column<Guid>(type: "TEXT", nullable: true),
                    RoadmapId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    StartedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TargetDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CompletedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Completed = table.Column<bool>(type: "INTEGER", nullable: false),
                    Favorited = table.Column<bool>(type: "INTEGER", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: true),
                    Icon = table.Column<string>(type: "TEXT", nullable: true),
                    Color = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedById = table.Column<string>(type: "TEXT", nullable: true),
                    AssigneeId = table.Column<string>(type: "TEXT", nullable: true),
                    ReviewerId = table.Column<string>(type: "TEXT", nullable: true),
                    StatusId = table.Column<Guid>(type: "TEXT", nullable: true),
                    PriorityId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Goal_IdentityUser_AssigneeId",
                        column: x => x.AssigneeId,
                        principalTable: "IdentityUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Goal_IdentityUser_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "IdentityUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Goal_IdentityUser_ReviewerId",
                        column: x => x.ReviewerId,
                        principalTable: "IdentityUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Goal_Priority_PriorityId",
                        column: x => x.PriorityId,
                        principalTable: "Priority",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Goal_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Goal_Roadmap_RoadmapId",
                        column: x => x.RoadmapId,
                        principalTable: "Roadmap",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Goal_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Milestone",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    GoalId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    StartedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TargetDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CompletedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Completed = table.Column<bool>(type: "INTEGER", nullable: false),
                    Favorited = table.Column<bool>(type: "INTEGER", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: true),
                    Icon = table.Column<string>(type: "TEXT", nullable: true),
                    Color = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedById = table.Column<string>(type: "TEXT", nullable: true),
                    AssigneeId = table.Column<string>(type: "TEXT", nullable: true),
                    ReviewerId = table.Column<string>(type: "TEXT", nullable: true),
                    StatusId = table.Column<Guid>(type: "TEXT", nullable: true),
                    PriorityId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Milestone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Milestone_Goal_GoalId",
                        column: x => x.GoalId,
                        principalTable: "Goal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Milestone_IdentityUser_AssigneeId",
                        column: x => x.AssigneeId,
                        principalTable: "IdentityUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Milestone_IdentityUser_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "IdentityUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Milestone_IdentityUser_ReviewerId",
                        column: x => x.ReviewerId,
                        principalTable: "IdentityUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Milestone_Priority_PriorityId",
                        column: x => x.PriorityId,
                        principalTable: "Priority",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Milestone_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ActivityEntry",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    MilestoneId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    StartedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TargetDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CompletedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Completed = table.Column<bool>(type: "INTEGER", nullable: false),
                    Favorited = table.Column<bool>(type: "INTEGER", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: true),
                    Icon = table.Column<string>(type: "TEXT", nullable: true),
                    Color = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedById = table.Column<string>(type: "TEXT", nullable: true),
                    AssigneeId = table.Column<string>(type: "TEXT", nullable: true),
                    ReviewerId = table.Column<string>(type: "TEXT", nullable: true),
                    StatusId = table.Column<Guid>(type: "TEXT", nullable: true),
                    PriorityId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityEntry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivityEntry_IdentityUser_AssigneeId",
                        column: x => x.AssigneeId,
                        principalTable: "IdentityUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ActivityEntry_IdentityUser_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "IdentityUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ActivityEntry_IdentityUser_ReviewerId",
                        column: x => x.ReviewerId,
                        principalTable: "IdentityUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ActivityEntry_Milestone_MilestoneId",
                        column: x => x.MilestoneId,
                        principalTable: "Milestone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityEntry_Priority_PriorityId",
                        column: x => x.PriorityId,
                        principalTable: "Priority",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ActivityEntry_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FileAttachment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TrackingRecordId = table.Column<Guid>(type: "TEXT", nullable: false),
                    FileName = table.Column<string>(type: "TEXT", nullable: true),
                    FileExtension = table.Column<string>(type: "TEXT", nullable: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    UploadedById = table.Column<string>(type: "TEXT", nullable: true),
                    UploadedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ActivityEntryId = table.Column<Guid>(type: "TEXT", nullable: true),
                    GoalId = table.Column<Guid>(type: "TEXT", nullable: true),
                    MilestoneId = table.Column<Guid>(type: "TEXT", nullable: true),
                    ProjectId = table.Column<Guid>(type: "TEXT", nullable: true),
                    RoadmapId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileAttachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileAttachment_ActivityEntry_ActivityEntryId",
                        column: x => x.ActivityEntryId,
                        principalTable: "ActivityEntry",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FileAttachment_Goal_GoalId",
                        column: x => x.GoalId,
                        principalTable: "Goal",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FileAttachment_IdentityUser_UploadedById",
                        column: x => x.UploadedById,
                        principalTable: "IdentityUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FileAttachment_Milestone_MilestoneId",
                        column: x => x.MilestoneId,
                        principalTable: "Milestone",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FileAttachment_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FileAttachment_Roadmap_RoadmapId",
                        column: x => x.RoadmapId,
                        principalTable: "Roadmap",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Link",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedById = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ActivityEntryId = table.Column<Guid>(type: "TEXT", nullable: true),
                    GoalId = table.Column<Guid>(type: "TEXT", nullable: true),
                    MilestoneId = table.Column<Guid>(type: "TEXT", nullable: true),
                    ProjectId = table.Column<Guid>(type: "TEXT", nullable: true),
                    RoadmapId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Link_ActivityEntry_ActivityEntryId",
                        column: x => x.ActivityEntryId,
                        principalTable: "ActivityEntry",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Link_Goal_GoalId",
                        column: x => x.GoalId,
                        principalTable: "Goal",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Link_IdentityUser_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "IdentityUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Link_Milestone_MilestoneId",
                        column: x => x.MilestoneId,
                        principalTable: "Milestone",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Link_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Link_Roadmap_RoadmapId",
                        column: x => x.RoadmapId,
                        principalTable: "Roadmap",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedById = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ActivityEntryId = table.Column<Guid>(type: "TEXT", nullable: true),
                    GoalId = table.Column<Guid>(type: "TEXT", nullable: true),
                    MilestoneId = table.Column<Guid>(type: "TEXT", nullable: true),
                    ProjectId = table.Column<Guid>(type: "TEXT", nullable: true),
                    RoadmapId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tag_ActivityEntry_ActivityEntryId",
                        column: x => x.ActivityEntryId,
                        principalTable: "ActivityEntry",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tag_Goal_GoalId",
                        column: x => x.GoalId,
                        principalTable: "Goal",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tag_IdentityUser_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "IdentityUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tag_Milestone_MilestoneId",
                        column: x => x.MilestoneId,
                        principalTable: "Milestone",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tag_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tag_Roadmap_RoadmapId",
                        column: x => x.RoadmapId,
                        principalTable: "Roadmap",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityEntry_AssigneeId",
                table: "ActivityEntry",
                column: "AssigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityEntry_CreatedById",
                table: "ActivityEntry",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityEntry_MilestoneId",
                table: "ActivityEntry",
                column: "MilestoneId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityEntry_PriorityId",
                table: "ActivityEntry",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityEntry_ReviewerId",
                table: "ActivityEntry",
                column: "ReviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityEntry_StatusId",
                table: "ActivityEntry",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId1",
                table: "AspNetUserClaims",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId1",
                table: "AspNetUserLogins",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserTokens_UserId1",
                table: "AspNetUserTokens",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_FileAttachment_ActivityEntryId",
                table: "FileAttachment",
                column: "ActivityEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_FileAttachment_GoalId",
                table: "FileAttachment",
                column: "GoalId");

            migrationBuilder.CreateIndex(
                name: "IX_FileAttachment_MilestoneId",
                table: "FileAttachment",
                column: "MilestoneId");

            migrationBuilder.CreateIndex(
                name: "IX_FileAttachment_ProjectId",
                table: "FileAttachment",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_FileAttachment_RoadmapId",
                table: "FileAttachment",
                column: "RoadmapId");

            migrationBuilder.CreateIndex(
                name: "IX_FileAttachment_UploadedById",
                table: "FileAttachment",
                column: "UploadedById");

            migrationBuilder.CreateIndex(
                name: "IX_Goal_AssigneeId",
                table: "Goal",
                column: "AssigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_Goal_CreatedById",
                table: "Goal",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Goal_PriorityId",
                table: "Goal",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_Goal_ProjectId",
                table: "Goal",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Goal_ReviewerId",
                table: "Goal",
                column: "ReviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_Goal_RoadmapId",
                table: "Goal",
                column: "RoadmapId");

            migrationBuilder.CreateIndex(
                name: "IX_Goal_StatusId",
                table: "Goal",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Link_ActivityEntryId",
                table: "Link",
                column: "ActivityEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_Link_CreatedById",
                table: "Link",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Link_GoalId",
                table: "Link",
                column: "GoalId");

            migrationBuilder.CreateIndex(
                name: "IX_Link_MilestoneId",
                table: "Link",
                column: "MilestoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Link_ProjectId",
                table: "Link",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Link_RoadmapId",
                table: "Link",
                column: "RoadmapId");

            migrationBuilder.CreateIndex(
                name: "IX_Milestone_AssigneeId",
                table: "Milestone",
                column: "AssigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_Milestone_CreatedById",
                table: "Milestone",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Milestone_GoalId",
                table: "Milestone",
                column: "GoalId");

            migrationBuilder.CreateIndex(
                name: "IX_Milestone_PriorityId",
                table: "Milestone",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_Milestone_ReviewerId",
                table: "Milestone",
                column: "ReviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_Milestone_StatusId",
                table: "Milestone",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Priority_CreatedById",
                table: "Priority",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Project_AssigneeId",
                table: "Project",
                column: "AssigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_CreatedById",
                table: "Project",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Project_PriorityId",
                table: "Project",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ReviewerId",
                table: "Project",
                column: "ReviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_StatusId",
                table: "Project",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Roadmap_AssigneeId",
                table: "Roadmap",
                column: "AssigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_Roadmap_CreatedById",
                table: "Roadmap",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Roadmap_PriorityId",
                table: "Roadmap",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_Roadmap_ProjectId",
                table: "Roadmap",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Roadmap_ReviewerId",
                table: "Roadmap",
                column: "ReviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_Roadmap_StatusId",
                table: "Roadmap",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Status_CreatedById",
                table: "Status",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_ActivityEntryId",
                table: "Tag",
                column: "ActivityEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_CreatedById",
                table: "Tag",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_GoalId",
                table: "Tag",
                column: "GoalId");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_MilestoneId",
                table: "Tag",
                column: "MilestoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_ProjectId",
                table: "Tag",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_RoadmapId",
                table: "Tag",
                column: "RoadmapId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "FileAttachment");

            migrationBuilder.DropTable(
                name: "Link");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ActivityEntry");

            migrationBuilder.DropTable(
                name: "Milestone");

            migrationBuilder.DropTable(
                name: "Goal");

            migrationBuilder.DropTable(
                name: "Roadmap");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Priority");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "IdentityUser");
        }
    }
}
