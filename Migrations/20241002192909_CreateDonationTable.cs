using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class CreateDonationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IncidentReports_AspNetUsers_ReportedByUserId",
                table: "IncidentReports");

            migrationBuilder.DropIndex(
                name: "IX_IncidentReports_ReportedByUserId",
                table: "IncidentReports");

            migrationBuilder.DropColumn(
                name: "ReportedByUserId",
                table: "IncidentReports");

            migrationBuilder.RenameColumn(
                name: "DateReported",
                table: "IncidentReports",
                newName: "DateSubmitted");

            migrationBuilder.AddColumn<Guid>(
                name: "SubmittedByUserId",
                table: "IncidentReports",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubmittedByUserId",
                table: "IncidentReports");

            migrationBuilder.RenameColumn(
                name: "DateSubmitted",
                table: "IncidentReports",
                newName: "DateReported");

            migrationBuilder.AddColumn<string>(
                name: "ReportedByUserId",
                table: "IncidentReports",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_IncidentReports_ReportedByUserId",
                table: "IncidentReports",
                column: "ReportedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_IncidentReports_AspNetUsers_ReportedByUserId",
                table: "IncidentReports",
                column: "ReportedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
