using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CafeteriaWebApi.Migrations
{
    /// <inheritdoc />
    public partial class FixQuantity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "IdOrder",
                keyValue: 1,
                columns: new[] { "DeliveryTime", "Quantity" },
                values: new object[] { new DateTime(2023, 11, 16, 18, 57, 31, 856, DateTimeKind.Local).AddTicks(829), 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "IdOrder",
                keyValue: 1,
                columns: new[] { "DeliveryTime", "Quantity" },
                values: new object[] { new DateTime(2023, 11, 16, 18, 55, 33, 844, DateTimeKind.Local).AddTicks(3814), 0m });
        }
    }
}
