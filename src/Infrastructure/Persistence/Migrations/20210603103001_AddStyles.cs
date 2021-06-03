using Microsoft.EntityFrameworkCore.Migrations;

namespace CloudyMobile.Infrastructure.Persistence.Migrations
{
    public partial class AddStyles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Style",
                table: "Recipes");

            migrationBuilder.AddColumn<int>(
                name: "StyleId",
                table: "Recipes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Styles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Styles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_StyleId",
                table: "Recipes",
                column: "StyleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Styles_StyleId",
                table: "Recipes",
                column: "StyleId",
                principalTable: "Styles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Styles_StyleId",
                table: "Recipes");

            migrationBuilder.DropTable(
                name: "Styles");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_StyleId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "StyleId",
                table: "Recipes");

            migrationBuilder.AddColumn<string>(
                name: "Style",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
