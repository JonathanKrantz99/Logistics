using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Logistics.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Name", "Removed" },
                values: new object[,]
                {
                    { new Guid("1d9e6531-357a-46cf-8e25-97d87b6f4efa"), "Headset", false },
                    { new Guid("69daaf92-54b1-432d-a90e-5d8d20f86d44"), "Monitor", false },
                    { new Guid("8e87285a-a19b-4198-a3de-e808e75c64af"), "Keyboard", false }
                });

            migrationBuilder.InsertData(
                table: "Supplier",
                columns: new[] { "Id", "Name", "Removed" },
                values: new object[,]
                {
                    { new Guid("5ebadc88-b0bc-4178-a5e8-d3b5faad8e3a"), "Supplier 2", false },
                    { new Guid("9386a7d2-498f-4c61-997d-f251e785c69c"), "Supplier 1", false }
                });

            migrationBuilder.InsertData(
                table: "Warehouse",
                columns: new[] { "Id", "Address_City", "Address_PostalCode", "Address_Street", "Address_StreetNumber", "Name", "Removed" },
                values: new object[,]
                {
                    { new Guid("d15e3230-949f-4739-963b-98d27d34f4d2"), "Falkenberg", "31173", "Södergatan", "18", "Warehouse 2", false },
                    { new Guid("d1d38bdf-ce2f-4f77-adf5-5d0773bb115e"), "Varberg", "43241", "Norrgatan", "13", "Warehouse 1", false }
                });

            migrationBuilder.InsertData(
                table: "ProductSupplier",
                columns: new[] { "Id", "ProductId", "SupplierId" },
                values: new object[,]
                {
                    { new Guid("01435be9-eb2c-4dde-94f6-1e90eb3f4190"), new Guid("8e87285a-a19b-4198-a3de-e808e75c64af"), new Guid("9386a7d2-498f-4c61-997d-f251e785c69c") },
                    { new Guid("4df454cd-ba22-4beb-b00d-7f448b2a33cb"), new Guid("1d9e6531-357a-46cf-8e25-97d87b6f4efa"), new Guid("9386a7d2-498f-4c61-997d-f251e785c69c") },
                    { new Guid("6980d6d6-e0df-4726-a6d0-229b966a5572"), new Guid("69daaf92-54b1-432d-a90e-5d8d20f86d44"), new Guid("5ebadc88-b0bc-4178-a5e8-d3b5faad8e3a") }
                });

            migrationBuilder.InsertData(
                table: "StockItem",
                columns: new[] { "Id", "ProductId", "Quantity", "SupplierId", "WarehouseId" },
                values: new object[,]
                {
                    { new Guid("663e29e9-4dc3-40e4-9f46-8708389eb30c"), new Guid("1d9e6531-357a-46cf-8e25-97d87b6f4efa"), 50, new Guid("9386a7d2-498f-4c61-997d-f251e785c69c"), new Guid("d1d38bdf-ce2f-4f77-adf5-5d0773bb115e") },
                    { new Guid("80629c52-a617-4322-a754-14dc72f508d6"), new Guid("69daaf92-54b1-432d-a90e-5d8d20f86d44"), 200, new Guid("5ebadc88-b0bc-4178-a5e8-d3b5faad8e3a"), new Guid("d15e3230-949f-4739-963b-98d27d34f4d2") },
                    { new Guid("9bb136af-1d61-4858-a002-da47994c6f2c"), new Guid("8e87285a-a19b-4198-a3de-e808e75c64af"), 40, new Guid("9386a7d2-498f-4c61-997d-f251e785c69c"), new Guid("d1d38bdf-ce2f-4f77-adf5-5d0773bb115e") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductSupplier",
                keyColumn: "Id",
                keyValue: new Guid("01435be9-eb2c-4dde-94f6-1e90eb3f4190"));

            migrationBuilder.DeleteData(
                table: "ProductSupplier",
                keyColumn: "Id",
                keyValue: new Guid("4df454cd-ba22-4beb-b00d-7f448b2a33cb"));

            migrationBuilder.DeleteData(
                table: "ProductSupplier",
                keyColumn: "Id",
                keyValue: new Guid("6980d6d6-e0df-4726-a6d0-229b966a5572"));

            migrationBuilder.DeleteData(
                table: "StockItem",
                keyColumn: "Id",
                keyValue: new Guid("663e29e9-4dc3-40e4-9f46-8708389eb30c"));

            migrationBuilder.DeleteData(
                table: "StockItem",
                keyColumn: "Id",
                keyValue: new Guid("80629c52-a617-4322-a754-14dc72f508d6"));

            migrationBuilder.DeleteData(
                table: "StockItem",
                keyColumn: "Id",
                keyValue: new Guid("9bb136af-1d61-4858-a002-da47994c6f2c"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("1d9e6531-357a-46cf-8e25-97d87b6f4efa"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("69daaf92-54b1-432d-a90e-5d8d20f86d44"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("8e87285a-a19b-4198-a3de-e808e75c64af"));

            migrationBuilder.DeleteData(
                table: "Supplier",
                keyColumn: "Id",
                keyValue: new Guid("5ebadc88-b0bc-4178-a5e8-d3b5faad8e3a"));

            migrationBuilder.DeleteData(
                table: "Supplier",
                keyColumn: "Id",
                keyValue: new Guid("9386a7d2-498f-4c61-997d-f251e785c69c"));

            migrationBuilder.DeleteData(
                table: "Warehouse",
                keyColumn: "Id",
                keyValue: new Guid("d15e3230-949f-4739-963b-98d27d34f4d2"));

            migrationBuilder.DeleteData(
                table: "Warehouse",
                keyColumn: "Id",
                keyValue: new Guid("d1d38bdf-ce2f-4f77-adf5-5d0773bb115e"));
        }
    }
}
