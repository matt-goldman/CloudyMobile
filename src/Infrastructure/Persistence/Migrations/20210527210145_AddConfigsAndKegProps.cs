using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CloudyMobile.Infrastructure.Persistence.Migrations
{
    public partial class AddConfigsAndKegProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BatchRatings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BatchId = table.Column<int>(type: "int", nullable: false),
                    RatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatchRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BatchRatings_Batches_BatchId",
                        column: x => x.BatchId,
                        principalTable: "Batches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kegs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BatchId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    DateKegged = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VolumeKegged = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kegs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kegs_Batches_BatchId",
                        column: x => x.BatchId,
                        principalTable: "Batches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kegs_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KegPours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KegId = table.Column<int>(type: "int", nullable: false),
                    PouredAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VolumePoured = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KegPours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KegPours_Kegs_KegId",
                        column: x => x.KegId,
                        principalTable: "Kegs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BatchRatings_BatchId",
                table: "BatchRatings",
                column: "BatchId");

            migrationBuilder.CreateIndex(
                name: "IX_KegPours_KegId",
                table: "KegPours",
                column: "KegId");

            migrationBuilder.CreateIndex(
                name: "IX_Kegs_BatchId",
                table: "Kegs",
                column: "BatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Kegs_LocationId",
                table: "Kegs",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BatchRatings");

            migrationBuilder.DropTable(
                name: "KegPours");

            migrationBuilder.DropTable(
                name: "Kegs");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
