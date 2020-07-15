using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeShop.API.Migrations
{
    public partial class updateTables1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_OrderProducts_OrderProductsOrderproductId",
                table: "OrderProducts");

            migrationBuilder.DropIndex(
                name: "IX_OrderProducts_OrderProductsOrderproductId",
                table: "OrderProducts");

            migrationBuilder.DropColumn(
                name: "OrderProductsOrderproductId",
                table: "OrderProducts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderProductsOrderproductId",
                table: "OrderProducts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_OrderProductsOrderproductId",
                table: "OrderProducts",
                column: "OrderProductsOrderproductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_OrderProducts_OrderProductsOrderproductId",
                table: "OrderProducts",
                column: "OrderProductsOrderproductId",
                principalTable: "OrderProducts",
                principalColumn: "OrderproductId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
