using Microsoft.EntityFrameworkCore.Migrations;

namespace CloudyMobile.Infrastructure.Persistence.Migrations
{
    public partial class AddBatchQuantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "BrewQuantity",
                table: "Batches",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrewQuantity",
                table: "Batches");
        }
    }
}
