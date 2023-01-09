using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_ASP_NET.Migrations
{
    public partial class DealerToContracts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DealerID",
                table: "Contract",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contract_DealerID",
                table: "Contract",
                column: "DealerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_Dealer_DealerID",
                table: "Contract",
                column: "DealerID",
                principalTable: "Dealer",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contract_Dealer_DealerID",
                table: "Contract");

            migrationBuilder.DropIndex(
                name: "IX_Contract_DealerID",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "DealerID",
                table: "Contract");
        }
    }
}
