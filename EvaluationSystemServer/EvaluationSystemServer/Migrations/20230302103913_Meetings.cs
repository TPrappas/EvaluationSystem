using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvaluationSystemServer.Migrations
{
    /// <inheritdoc />
    public partial class Meetings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobApplicationEntity_JobPositions_JobPositionId",
                table: "JobApplicationEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_JobApplicationEntity_Users_UserId",
                table: "JobApplicationEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Users_EmployeeId",
                table: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobApplicationEntity",
                table: "JobApplicationEntity");

            migrationBuilder.RenameTable(
                name: "JobApplicationEntity",
                newName: "JobApplications");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Projects",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_EmployeeId",
                table: "Projects",
                newName: "IX_Projects_UserId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "JobApplications",
                newName: "ManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_JobApplicationEntity_UserId",
                table: "JobApplications",
                newName: "IX_JobApplications_ManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_JobApplicationEntity_JobPositionId",
                table: "JobApplications",
                newName: "IX_JobApplications_JobPositionId");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "JobApplications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EvaluatorId",
                table: "JobApplications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobApplications",
                table: "JobApplications",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Meetings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeetingDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Topic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meetings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meetings_Users_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Meetings_Users_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_EmployeeId",
                table: "JobApplications",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_EvaluatorId",
                table: "JobApplications",
                column: "EvaluatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ProjectId",
                table: "Categories",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_EmployeeId",
                table: "Meetings",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_ManagerId",
                table: "Meetings",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_JobPositions_JobPositionId",
                table: "JobApplications",
                column: "JobPositionId",
                principalTable: "JobPositions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_Users_EmployeeId",
                table: "JobApplications",
                column: "EmployeeId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_Users_EvaluatorId",
                table: "JobApplications",
                column: "EvaluatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_Users_ManagerId",
                table: "JobApplications",
                column: "ManagerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_UserId",
                table: "Projects",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_JobPositions_JobPositionId",
                table: "JobApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_Users_EmployeeId",
                table: "JobApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_Users_EvaluatorId",
                table: "JobApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_Users_ManagerId",
                table: "JobApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Users_UserId",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Meetings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobApplications",
                table: "JobApplications");

            migrationBuilder.DropIndex(
                name: "IX_JobApplications_EmployeeId",
                table: "JobApplications");

            migrationBuilder.DropIndex(
                name: "IX_JobApplications_EvaluatorId",
                table: "JobApplications");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "JobApplications");

            migrationBuilder.DropColumn(
                name: "EvaluatorId",
                table: "JobApplications");

            migrationBuilder.RenameTable(
                name: "JobApplications",
                newName: "JobApplicationEntity");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Projects",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_UserId",
                table: "Projects",
                newName: "IX_Projects_EmployeeId");

            migrationBuilder.RenameColumn(
                name: "ManagerId",
                table: "JobApplicationEntity",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_JobApplications_ManagerId",
                table: "JobApplicationEntity",
                newName: "IX_JobApplicationEntity_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_JobApplications_JobPositionId",
                table: "JobApplicationEntity",
                newName: "IX_JobApplicationEntity_JobPositionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobApplicationEntity",
                table: "JobApplicationEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplicationEntity_JobPositions_JobPositionId",
                table: "JobApplicationEntity",
                column: "JobPositionId",
                principalTable: "JobPositions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplicationEntity_Users_UserId",
                table: "JobApplicationEntity",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_EmployeeId",
                table: "Projects",
                column: "EmployeeId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
