using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NetPablo.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ProductDataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "AlternativeName", "CreationDate", "Name", "Price", "Status" },
                values: new object[,]
                {
                    { 1, "Telefono Alcatel", new DateTime(2023, 1, 7, 0, 44, 14, 847, DateTimeKind.Local).AddTicks(9124), "Telefono celular", 50000.0, true },
                    { 2, "Marca Naik", new DateTime(2023, 1, 7, 0, 44, 14, 847, DateTimeKind.Local).AddTicks(9159), "Zapatilla", 25000.0, true },
                    { 3, "Fruta organica", new DateTime(2023, 1, 7, 0, 44, 14, 847, DateTimeKind.Local).AddTicks(9162), "Manzana", 150.0, true },
                    { 4, "Chaleco de lana", new DateTime(2023, 1, 7, 0, 44, 14, 847, DateTimeKind.Local).AddTicks(9164), "Chaleco", 35000.0, true },
                    { 5, "Mouse con bluetooth", new DateTime(2023, 1, 7, 0, 44, 14, 847, DateTimeKind.Local).AddTicks(9166), "Mouse Inalambrico", 15000.0, true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
