using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class AddTitleToIncidentReport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReportedOn",
                table: "IncidentReports",
                newName: "DateReported");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "IncidentReports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReportedByUserId",
                table: "IncidentReports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "IncidentReports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Donations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "IncidentReports");

            migrationBuilder.DropColumn(
                name: "ReportedByUserId",
                table: "IncidentReports");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "IncidentReports");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Donations");

            migrationBuilder.RenameColumn(
                name: "DateReported",
                table: "IncidentReports",
                newName: "ReportedOn");
        }
    }
}
