using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_ASP_NET.Migrations
{
    public partial class carCategoryUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarCategory");

            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Car",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Car_CategoryID",
                table: "Car",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Category_CategoryID",
                table: "Car",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_Category_CategoryID",
                table: "Car");

            migrationBuilder.DropIndex(
                name: "IX_Car_CategoryID",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Car");

            migrationBuilder.CreateTable(
                name: "CarCategory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarID = table.Column<int>(type: "int", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CarCategory_Car_CarID",
                        column: x => x.CarID,
                        principalTable: "Car",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarCategory_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarCategory_CarID",
                table: "CarCategory",
                column: "CarID");

            migrationBuilder.CreateIndex(
                name: "IX_CarCategory_CategoryID",
                table: "CarCategory",
                column: "CategoryID");
        }
    }
}
