using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Restaurante.Infra.Data.Migrations
{
    public partial class CreateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "restaurant",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_restaurant", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dish",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    description = table.Column<string>(maxLength: 100, nullable: false),
                    price = table.Column<float>(nullable: false),
                    restaurant_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dish", x => x.id);
                    table.ForeignKey(
                        name: "FK_dish_restaurant_restaurant_id",
                        column: x => x.restaurant_id,
                        principalTable: "restaurant",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_dish_restaurant_id",
                table: "dish",
                column: "restaurant_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dish");

            migrationBuilder.DropTable(
                name: "restaurant");
        }
    }
}
