using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Consultations.Migrations
{
    public partial class StartDateAndEndDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Time",
                table: "Consultations",
                newName: "StartDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Consultations",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Consultations");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Consultations",
                newName: "Time");
        }
    }
}
