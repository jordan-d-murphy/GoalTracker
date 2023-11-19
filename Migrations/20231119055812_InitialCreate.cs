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
                name: "Kai",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Model = table.Column<string>(type: "TEXT", nullable: true),
                    Prompt = table.Column<string>(type: "TEXT", nullable: true),
                    Response = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kai", x => x.Id);
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
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CustomTag = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    State = table.Column<string>(type: "TEXT", nullable: true),
                    Zip = table.Column<string>(type: "TEXT", nullable: true),
                    DisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    DOB = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OnlinePresenceIndicator = table.Column<DateTime>(type: "TEXT", nullable: true),
                    TeamId = table.Column<Guid>(type: "TEXT", nullable: true),
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
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    MessageBody = table.Column<string>(type: "TEXT", nullable: true),
                    SenderId = table.Column<Guid>(type: "TEXT", nullable: true),
                    ReceiverId = table.Column<Guid>(type: "TEXT", nullable: true),
                    SentTimestamp = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeliveredTimestamp = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ReadTimestamp = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Read = table.Column<bool>(type: "INTEGER", nullable: false),
                    GeneratedByApplication = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notification_AspNetUsers_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Notification_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Subscription",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedById = table.Column<Guid>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Tier = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<string>(type: "TEXT", nullable: true),
                    Details = table.Column<string>(type: "TEXT", nullable: true),
                    BillingFrequency = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscription_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TrackingRecord",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ParentId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    StartedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    TargetDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CompletedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Completed = table.Column<bool>(type: "INTEGER", nullable: false),
                    Favorited = table.Column<bool>(type: "INTEGER", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: true),
                    Icon = table.Column<string>(type: "TEXT", nullable: true),
                    Color = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedById = table.Column<Guid>(type: "TEXT", nullable: true),
                    AssigneeId = table.Column<Guid>(type: "TEXT", nullable: true),
                    ReviewerId = table.Column<Guid>(type: "TEXT", nullable: true),
                    StatusId = table.Column<Guid>(type: "TEXT", nullable: true),
                    PriorityId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    Dash_Name = table.Column<string>(type: "TEXT", nullable: true),
                    DashViz_Name = table.Column<string>(type: "TEXT", nullable: true),
                    DashViz_TypeId = table.Column<Guid>(type: "TEXT", nullable: true),
                    DashViz_JSONData = table.Column<string>(type: "TEXT", nullable: true),
                    DashId = table.Column<Guid>(type: "TEXT", nullable: true),
                    FileName = table.Column<string>(type: "TEXT", nullable: true),
                    FileExtension = table.Column<string>(type: "TEXT", nullable: true),
                    FileAttachment_Url = table.Column<string>(type: "TEXT", nullable: true),
                    FileAttachment_TrackingRecordId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Action = table.Column<string>(type: "TEXT", nullable: true),
                    History_TrackingRecordId = table.Column<Guid>(type: "TEXT", nullable: true),
                    History_Url = table.Column<string>(type: "TEXT", nullable: true),
                    DisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    Link_TrackingRecordId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Metric_Name = table.Column<string>(type: "TEXT", nullable: true),
                    Metric_TypeId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Metric_JSONData = table.Column<string>(type: "TEXT", nullable: true),
                    MetricType_Name = table.Column<string>(type: "TEXT", nullable: true),
                    MetricType_JSONData = table.Column<string>(type: "TEXT", nullable: true),
                    Text = table.Column<string>(type: "TEXT", nullable: true),
                    Note_TrackingRecordId = table.Column<Guid>(type: "TEXT", nullable: true),
                    TeamId = table.Column<Guid>(type: "TEXT", nullable: true),
                    PriorityInt = table.Column<int>(type: "INTEGER", nullable: true),
                    Report_Name = table.Column<string>(type: "TEXT", nullable: true),
                    Report_TypeId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Report_JSONData = table.Column<string>(type: "TEXT", nullable: true),
                    Settings_Name = table.Column<string>(type: "TEXT", nullable: true),
                    TypeId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Settings_JSONData = table.Column<string>(type: "TEXT", nullable: true),
                    TrackingRecordId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    JSONData = table.Column<string>(type: "TEXT", nullable: true),
                    VizType_Name = table.Column<string>(type: "TEXT", nullable: true),
                    VizType_JSONData = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackingRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrackingRecord_AspNetUsers_AssigneeId",
                        column: x => x.AssigneeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TrackingRecord_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TrackingRecord_AspNetUsers_ReviewerId",
                        column: x => x.ReviewerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TrackingRecord_TrackingRecord_DashId",
                        column: x => x.DashId,
                        principalTable: "TrackingRecord",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrackingRecord_TrackingRecord_DashViz_TypeId",
                        column: x => x.DashViz_TypeId,
                        principalTable: "TrackingRecord",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TrackingRecord_TrackingRecord_FileAttachment_TrackingRecordId",
                        column: x => x.FileAttachment_TrackingRecordId,
                        principalTable: "TrackingRecord",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TrackingRecord_TrackingRecord_History_TrackingRecordId",
                        column: x => x.History_TrackingRecordId,
                        principalTable: "TrackingRecord",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TrackingRecord_TrackingRecord_Link_TrackingRecordId",
                        column: x => x.Link_TrackingRecordId,
                        principalTable: "TrackingRecord",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TrackingRecord_TrackingRecord_Metric_TypeId",
                        column: x => x.Metric_TypeId,
                        principalTable: "TrackingRecord",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TrackingRecord_TrackingRecord_Note_TrackingRecordId",
                        column: x => x.Note_TrackingRecordId,
                        principalTable: "TrackingRecord",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TrackingRecord_TrackingRecord_ParentId",
                        column: x => x.ParentId,
                        principalTable: "TrackingRecord",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TrackingRecord_TrackingRecord_PriorityId",
                        column: x => x.PriorityId,
                        principalTable: "TrackingRecord",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TrackingRecord_TrackingRecord_Report_TypeId",
                        column: x => x.Report_TypeId,
                        principalTable: "TrackingRecord",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TrackingRecord_TrackingRecord_StatusId",
                        column: x => x.StatusId,
                        principalTable: "TrackingRecord",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TrackingRecord_TrackingRecord_TeamId",
                        column: x => x.TeamId,
                        principalTable: "TrackingRecord",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TrackingRecord_TrackingRecord_TrackingRecordId",
                        column: x => x.TrackingRecordId,
                        principalTable: "TrackingRecord",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TrackingRecord_TrackingRecord_TypeId",
                        column: x => x.TypeId,
                        principalTable: "TrackingRecord",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Billing",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: true),
                    CreatedById = table.Column<Guid>(type: "TEXT", nullable: true),
                    SubscriptionId = table.Column<Guid>(type: "TEXT", nullable: true),
                    BillingDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DueDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    PaidDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Paid = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Billing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Billing_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Billing_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Billing_Subscription_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "Subscription",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ReactionEmoji",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Emoji = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedById = table.Column<Guid>(type: "TEXT", nullable: true),
                    TrackingRecordId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReactionEmoji", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReactionEmoji_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReactionEmoji_TrackingRecord_TrackingRecordId",
                        column: x => x.TrackingRecordId,
                        principalTable: "TrackingRecord",
                        principalColumn: "Id");
                });

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
                name: "IX_AspNetUsers_TeamId",
                table: "AspNetUsers",
                column: "TeamId");

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
                name: "IX_Billing_CreatedById",
                table: "Billing",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Billing_SubscriptionId",
                table: "Billing",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Billing_UserId",
                table: "Billing",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_ReceiverId",
                table: "Notification",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_SenderId",
                table: "Notification",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_ReactionEmoji_CreatedById",
                table: "ReactionEmoji",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ReactionEmoji_TrackingRecordId",
                table: "ReactionEmoji",
                column: "TrackingRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_CreatedById",
                table: "Subscription",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_TrackingRecord_AssigneeId",
                table: "TrackingRecord",
                column: "AssigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackingRecord_CreatedById",
                table: "TrackingRecord",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_TrackingRecord_DashId",
                table: "TrackingRecord",
                column: "DashId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackingRecord_DashViz_TypeId",
                table: "TrackingRecord",
                column: "DashViz_TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackingRecord_FileAttachment_TrackingRecordId",
                table: "TrackingRecord",
                column: "FileAttachment_TrackingRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackingRecord_History_TrackingRecordId",
                table: "TrackingRecord",
                column: "History_TrackingRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackingRecord_Link_TrackingRecordId",
                table: "TrackingRecord",
                column: "Link_TrackingRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackingRecord_Metric_TypeId",
                table: "TrackingRecord",
                column: "Metric_TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackingRecord_Note_TrackingRecordId",
                table: "TrackingRecord",
                column: "Note_TrackingRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackingRecord_ParentId",
                table: "TrackingRecord",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackingRecord_PriorityId",
                table: "TrackingRecord",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackingRecord_Report_TypeId",
                table: "TrackingRecord",
                column: "Report_TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackingRecord_ReviewerId",
                table: "TrackingRecord",
                column: "ReviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackingRecord_StatusId",
                table: "TrackingRecord",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackingRecord_TeamId",
                table: "TrackingRecord",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackingRecord_TrackingRecordId",
                table: "TrackingRecord",
                column: "TrackingRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackingRecord_TypeId",
                table: "TrackingRecord",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId1",
                table: "AspNetUserClaims",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId1",
                table: "AspNetUserLogins",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_TrackingRecord_TeamId",
                table: "AspNetUsers",
                column: "TeamId",
                principalTable: "TrackingRecord",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrackingRecord_AspNetUsers_AssigneeId",
                table: "TrackingRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_TrackingRecord_AspNetUsers_CreatedById",
                table: "TrackingRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_TrackingRecord_AspNetUsers_ReviewerId",
                table: "TrackingRecord");

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
                name: "Billing");

            migrationBuilder.DropTable(
                name: "Kai");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "ReactionEmoji");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Subscription");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "TrackingRecord");
        }
    }
}
