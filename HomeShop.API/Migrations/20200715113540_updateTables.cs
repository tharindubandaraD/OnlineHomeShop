using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeShop.API.Migrations
{
    public partial class updateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderProducts_OrderProductId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderProductId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderProductId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "OrderProducts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderProductsOrderproductId",
                table: "OrderProducts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_OrderId",
                table: "OrderProducts",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_OrderProductsOrderproductId",
                table: "OrderProducts",
                column: "OrderProductsOrderproductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_Orders_OrderId",
                table: "OrderProducts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_OrderProducts_OrderProductsOrderproductId",
                table: "OrderProducts",
                column: "OrderProductsOrderproductId",
                principalTable: "OrderProducts",
                principalColumn: "OrderproductId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_Orders_OrderId",
                table: "OrderProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_OrderProducts_OrderProductsOrderproductId",
                table: "OrderProducts");

            migrationBuilder.DropIndex(
                name: "IX_OrderProducts_OrderId",
                table: "OrderProducts");

            migrationBuilder.DropIndex(
                name: "IX_OrderProducts_OrderProductsOrderproductId",
                table: "OrderProducts");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "OrderProducts");

            migrationBuilder.DropColumn(
                name: "OrderProductsOrderproductId",
                table: "OrderProducts");

            migrationBuilder.AddColumn<int>(
                name: "OrderProductId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderProductId",
                table: "Orders",
                column: "OrderProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderProducts_OrderProductId",
                table: "Orders",
                column: "OrderProductId",
                principalTable: "OrderProducts",
                principalColumn: "OrderproductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
