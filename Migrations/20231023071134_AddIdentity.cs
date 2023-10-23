using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoalTracker.Migrations
{
    /// <inheritdoc />
    public partial class AddIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityEntry_IdentityUser_AssigneeId",
                table: "ActivityEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivityEntry_IdentityUser_CreatedById",
                table: "ActivityEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivityEntry_IdentityUser_ReviewerId",
                table: "ActivityEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_FileAttachment_IdentityUser_UploadedById",
                table: "FileAttachment");

            migrationBuilder.DropForeignKey(
                name: "FK_Goal_IdentityUser_AssigneeId",
                table: "Goal");

            migrationBuilder.DropForeignKey(
                name: "FK_Goal_IdentityUser_CreatedById",
                table: "Goal");

            migrationBuilder.DropForeignKey(
                name: "FK_Goal_IdentityUser_ReviewerId",
                table: "Goal");

            migrationBuilder.DropForeignKey(
                name: "FK_Link_IdentityUser_CreatedById",
                table: "Link");

            migrationBuilder.DropForeignKey(
                name: "FK_Milestone_IdentityUser_AssigneeId",
                table: "Milestone");

            migrationBuilder.DropForeignKey(
                name: "FK_Milestone_IdentityUser_CreatedById",
                table: "Milestone");

            migrationBuilder.DropForeignKey(
                name: "FK_Milestone_IdentityUser_ReviewerId",
                table: "Milestone");

            migrationBuilder.DropForeignKey(
                name: "FK_Priority_IdentityUser_CreatedById",
                table: "Priority");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_IdentityUser_AssigneeId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_IdentityUser_CreatedById",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_IdentityUser_ReviewerId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Roadmap_IdentityUser_AssigneeId",
                table: "Roadmap");

            migrationBuilder.DropForeignKey(
                name: "FK_Roadmap_IdentityUser_CreatedById",
                table: "Roadmap");

            migrationBuilder.DropForeignKey(
                name: "FK_Roadmap_IdentityUser_ReviewerId",
                table: "Roadmap");

            migrationBuilder.DropForeignKey(
                name: "FK_Status_IdentityUser_CreatedById",
                table: "Status");

            migrationBuilder.DropForeignKey(
                name: "FK_Tag_IdentityUser_CreatedById",
                table: "Tag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityUser",
                table: "IdentityUser");

            migrationBuilder.RenameTable(
                name: "IdentityUser",
                newName: "AspNetUsers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
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
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
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
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityEntry_AspNetUsers_AssigneeId",
                table: "ActivityEntry",
                column: "AssigneeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityEntry_AspNetUsers_CreatedById",
                table: "ActivityEntry",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityEntry_AspNetUsers_ReviewerId",
                table: "ActivityEntry",
                column: "ReviewerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FileAttachment_AspNetUsers_UploadedById",
                table: "FileAttachment",
                column: "UploadedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Goal_AspNetUsers_AssigneeId",
                table: "Goal",
                column: "AssigneeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Goal_AspNetUsers_CreatedById",
                table: "Goal",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Goal_AspNetUsers_ReviewerId",
                table: "Goal",
                column: "ReviewerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Link_AspNetUsers_CreatedById",
                table: "Link",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Milestone_AspNetUsers_AssigneeId",
                table: "Milestone",
                column: "AssigneeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Milestone_AspNetUsers_CreatedById",
                table: "Milestone",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Milestone_AspNetUsers_ReviewerId",
                table: "Milestone",
                column: "ReviewerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Priority_AspNetUsers_CreatedById",
                table: "Priority",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_AspNetUsers_AssigneeId",
                table: "Project",
                column: "AssigneeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_AspNetUsers_CreatedById",
                table: "Project",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_AspNetUsers_ReviewerId",
                table: "Project",
                column: "ReviewerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Roadmap_AspNetUsers_AssigneeId",
                table: "Roadmap",
                column: "AssigneeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Roadmap_AspNetUsers_CreatedById",
                table: "Roadmap",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Roadmap_AspNetUsers_ReviewerId",
                table: "Roadmap",
                column: "ReviewerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Status_AspNetUsers_CreatedById",
                table: "Status",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_AspNetUsers_CreatedById",
                table: "Tag",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityEntry_AspNetUsers_AssigneeId",
                table: "ActivityEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivityEntry_AspNetUsers_CreatedById",
                table: "ActivityEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivityEntry_AspNetUsers_ReviewerId",
                table: "ActivityEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_FileAttachment_AspNetUsers_UploadedById",
                table: "FileAttachment");

            migrationBuilder.DropForeignKey(
                name: "FK_Goal_AspNetUsers_AssigneeId",
                table: "Goal");

            migrationBuilder.DropForeignKey(
                name: "FK_Goal_AspNetUsers_CreatedById",
                table: "Goal");

            migrationBuilder.DropForeignKey(
                name: "FK_Goal_AspNetUsers_ReviewerId",
                table: "Goal");

            migrationBuilder.DropForeignKey(
                name: "FK_Link_AspNetUsers_CreatedById",
                table: "Link");

            migrationBuilder.DropForeignKey(
                name: "FK_Milestone_AspNetUsers_AssigneeId",
                table: "Milestone");

            migrationBuilder.DropForeignKey(
                name: "FK_Milestone_AspNetUsers_CreatedById",
                table: "Milestone");

            migrationBuilder.DropForeignKey(
                name: "FK_Milestone_AspNetUsers_ReviewerId",
                table: "Milestone");

            migrationBuilder.DropForeignKey(
                name: "FK_Priority_AspNetUsers_CreatedById",
                table: "Priority");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_AspNetUsers_AssigneeId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_AspNetUsers_CreatedById",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_AspNetUsers_ReviewerId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Roadmap_AspNetUsers_AssigneeId",
                table: "Roadmap");

            migrationBuilder.DropForeignKey(
                name: "FK_Roadmap_AspNetUsers_CreatedById",
                table: "Roadmap");

            migrationBuilder.DropForeignKey(
                name: "FK_Roadmap_AspNetUsers_ReviewerId",
                table: "Roadmap");

            migrationBuilder.DropForeignKey(
                name: "FK_Status_AspNetUsers_CreatedById",
                table: "Status");

            migrationBuilder.DropForeignKey(
                name: "FK_Tag_AspNetUsers_CreatedById",
                table: "Tag");

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
                name: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "EmailIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "IdentityUser");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityUser",
                table: "IdentityUser",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityEntry_IdentityUser_AssigneeId",
                table: "ActivityEntry",
                column: "AssigneeId",
                principalTable: "IdentityUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityEntry_IdentityUser_CreatedById",
                table: "ActivityEntry",
                column: "CreatedById",
                principalTable: "IdentityUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityEntry_IdentityUser_ReviewerId",
                table: "ActivityEntry",
                column: "ReviewerId",
                principalTable: "IdentityUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FileAttachment_IdentityUser_UploadedById",
                table: "FileAttachment",
                column: "UploadedById",
                principalTable: "IdentityUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Goal_IdentityUser_AssigneeId",
                table: "Goal",
                column: "AssigneeId",
                principalTable: "IdentityUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Goal_IdentityUser_CreatedById",
                table: "Goal",
                column: "CreatedById",
                principalTable: "IdentityUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Goal_IdentityUser_ReviewerId",
                table: "Goal",
                column: "ReviewerId",
                principalTable: "IdentityUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Link_IdentityUser_CreatedById",
                table: "Link",
                column: "CreatedById",
                principalTable: "IdentityUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Milestone_IdentityUser_AssigneeId",
                table: "Milestone",
                column: "AssigneeId",
                principalTable: "IdentityUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Milestone_IdentityUser_CreatedById",
                table: "Milestone",
                column: "CreatedById",
                principalTable: "IdentityUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Milestone_IdentityUser_ReviewerId",
                table: "Milestone",
                column: "ReviewerId",
                principalTable: "IdentityUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Priority_IdentityUser_CreatedById",
                table: "Priority",
                column: "CreatedById",
                principalTable: "IdentityUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_IdentityUser_AssigneeId",
                table: "Project",
                column: "AssigneeId",
                principalTable: "IdentityUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_IdentityUser_CreatedById",
                table: "Project",
                column: "CreatedById",
                principalTable: "IdentityUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_IdentityUser_ReviewerId",
                table: "Project",
                column: "ReviewerId",
                principalTable: "IdentityUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Roadmap_IdentityUser_AssigneeId",
                table: "Roadmap",
                column: "AssigneeId",
                principalTable: "IdentityUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Roadmap_IdentityUser_CreatedById",
                table: "Roadmap",
                column: "CreatedById",
                principalTable: "IdentityUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Roadmap_IdentityUser_ReviewerId",
                table: "Roadmap",
                column: "ReviewerId",
                principalTable: "IdentityUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Status_IdentityUser_CreatedById",
                table: "Status",
                column: "CreatedById",
                principalTable: "IdentityUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_IdentityUser_CreatedById",
                table: "Tag",
                column: "CreatedById",
                principalTable: "IdentityUser",
                principalColumn: "Id");
        }
    }
}
