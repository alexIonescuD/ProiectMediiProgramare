using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_ASP_NET.Migrations
{
    public partial class brandAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Car");

            migrationBuilder.AddColumn<int>(
                name: "BrandID",
                table: "Car",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DealerID",
                table: "Car",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstablishedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BrandID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Brand_Brand_BrandID",
                        column: x => x.BrandID,
                        principalTable: "Brand",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Dealer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DealerName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dealer", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_BrandID",
                table: "Car",
                column: "BrandID");

            migrationBuilder.CreateIndex(
                name: "IX_Car_DealerID",
                table: "Car",
                column: "DealerID");

            migrationBuilder.CreateIndex(
                name: "IX_Brand_BrandID",
                table: "Brand",
                column: "BrandID");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Brand_BrandID",
                table: "Car",
                column: "BrandID",
                principalTable: "Brand",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Dealer_DealerID",
                table: "Car",
                column: "DealerID",
                principalTable: "Dealer",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_Brand_BrandID",
                table: "Car");

            migrationBuilder.DropForeignKey(
                name: "FK_Car_Dealer_DealerID",
                table: "Car");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Dealer");

            migrationBuilder.DropIndex(
                name: "IX_Car_BrandID",
                table: "Car");

            migrationBuilder.DropIndex(
                name: "IX_Car_DealerID",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "BrandID",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "DealerID",
                table: "Car");

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Car",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
