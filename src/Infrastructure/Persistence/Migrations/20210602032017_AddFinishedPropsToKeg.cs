using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CloudyMobile.Infrastructure.Persistence.Migrations
{
    public partial class AddFinishedPropsToKeg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateFinished",
                table: "Kegs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Finished",
                table: "Kegs",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateFinished",
                table: "Kegs");

            migrationBuilder.DropColumn(
                name: "Finished",
                table: "Kegs");
        }
    }
}
