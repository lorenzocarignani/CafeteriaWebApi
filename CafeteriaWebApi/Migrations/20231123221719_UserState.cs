using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CafeteriaWebApi.Migrations
{
    /// <inheritdoc />
    public partial class UserState : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_AdminId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_AdminId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Users",
                newName: "UserState");

            migrationBuilder.AlterColumn<string>(
                name: "NameOrder",
                table: "Orders",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.CreateTable(
                name: "ProductSaleOrderLine",
                columns: table => new
                {
                    ProductIdProduct = table.Column<int>(type: "INTEGER", nullable: false),
                    SaleOrderLinesIdSaleOrderLine = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSaleOrderLine", x => new { x.ProductIdProduct, x.SaleOrderLinesIdSaleOrderLine });
                    table.ForeignKey(
                        name: "FK_ProductSaleOrderLine_Products_ProductIdProduct",
                        column: x => x.ProductIdProduct,
                        principalTable: "Products",
                        principalColumn: "IdProduct",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSaleOrderLine_SaleOrderLines_SaleOrderLinesIdSaleOrderLine",
                        column: x => x.SaleOrderLinesIdSaleOrderLine,
                        principalTable: "SaleOrderLines",
                        principalColumn: "IdSaleOrderLine",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "IdOrder",
                keyValue: 1,
                column: "DeliveryTime",
                value: new DateTime(2023, 11, 23, 19, 17, 18, 886, DateTimeKind.Local).AddTicks(7670));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserState",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserState",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_ProductSaleOrderLine_SaleOrderLinesIdSaleOrderLine",
                table: "ProductSaleOrderLine",
                column: "SaleOrderLinesIdSaleOrderLine");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductSaleOrderLine");

            migrationBuilder.RenameColumn(
                name: "UserState",
                table: "Users",
                newName: "State");

            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "Products",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NameOrder",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "IdOrder",
                keyValue: 1,
                column: "DeliveryTime",
                value: new DateTime(2023, 11, 16, 23, 55, 15, 695, DateTimeKind.Local).AddTicks(2950));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "IdProduct",
                keyValue: 1,
                column: "AdminId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "State",
                value: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "State",
                value: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_AdminId",
                table: "Products",
                column: "AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_AdminId",
                table: "Products",
                column: "AdminId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
