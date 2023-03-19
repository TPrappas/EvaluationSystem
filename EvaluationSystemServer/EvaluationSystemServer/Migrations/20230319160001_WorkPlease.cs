using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvaluationSystemServer.Migrations
{
    /// <inheritdoc />
    public partial class WorkPlease : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrganizerMeetings");

            migrationBuilder.RenameColumn(
                name: "StartingDate",
                table: "Projects",
                newName: "SubmissionStart");

            migrationBuilder.RenameColumn(
                name: "EndingDate",
                table: "Projects",
                newName: "SubmissionEnd");

            migrationBuilder.RenameColumn(
                name: "GradutationYear",
                table: "Certificates",
                newName: "GradugtationYear");

            migrationBuilder.AddColumn<double>(
                name: "Grade",
                table: "Projects",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "isSubmitted",
                table: "Projects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "OrganizerId",
                table: "Meetings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "Salary",
                table: "Jobs",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_OrganizerId",
                table: "Meetings",
                column: "OrganizerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meetings_Users_OrganizerId",
                table: "Meetings",
                column: "OrganizerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_Users_OrganizerId",
                table: "Meetings");

            migrationBuilder.DropIndex(
                name: "IX_Meetings_OrganizerId",
                table: "Meetings");

            migrationBuilder.DropColumn(
                name: "Grade",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "isSubmitted",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "OrganizerId",
                table: "Meetings");

            migrationBuilder.RenameColumn(
                name: "SubmissionStart",
                table: "Projects",
                newName: "StartingDate");

            migrationBuilder.RenameColumn(
                name: "SubmissionEnd",
                table: "Projects",
                newName: "EndingDate");

            migrationBuilder.RenameColumn(
                name: "GradugtationYear",
                table: "Certificates",
                newName: "GradutationYear");

            migrationBuilder.AlterColumn<int>(
                name: "Salary",
                table: "Jobs",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateTable(
                name: "OrganizerMeetings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeetingId = table.Column<int>(type: "int", nullable: false),
                    OrganizerId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizerMeetings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizerMeetings_Meetings_MeetingId",
                        column: x => x.MeetingId,
                        principalTable: "Meetings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OrganizerMeetings_Users_OrganizerId",
                        column: x => x.OrganizerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizerMeetings_MeetingId",
                table: "OrganizerMeetings",
                column: "MeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizerMeetings_OrganizerId",
                table: "OrganizerMeetings",
                column: "OrganizerId");
        }
    }
}
