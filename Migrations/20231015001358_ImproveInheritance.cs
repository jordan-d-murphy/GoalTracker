using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoalTracker.Migrations
{
    /// <inheritdoc />
    public partial class ImproveInheritance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityEntry_Milestone_MilestoneId",
                table: "ActivityEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_Milestone_Goal_GoalId",
                table: "Milestone");

            migrationBuilder.AlterColumn<int>(
                name: "GoalId",
                table: "Milestone",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MilestoneId",
                table: "ActivityEntry",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityEntry_Milestone_MilestoneId",
                table: "ActivityEntry",
                column: "MilestoneId",
                principalTable: "Milestone",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Milestone_Goal_GoalId",
                table: "Milestone",
                column: "GoalId",
                principalTable: "Goal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityEntry_Milestone_MilestoneId",
                table: "ActivityEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_Milestone_Goal_GoalId",
                table: "Milestone");

            migrationBuilder.AlterColumn<int>(
                name: "GoalId",
                table: "Milestone",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "MilestoneId",
                table: "ActivityEntry",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityEntry_Milestone_MilestoneId",
                table: "ActivityEntry",
                column: "MilestoneId",
                principalTable: "Milestone",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Milestone_Goal_GoalId",
                table: "Milestone",
                column: "GoalId",
                principalTable: "Goal",
                principalColumn: "Id");
        }
    }
}
