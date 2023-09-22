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
                    { new Guid("04462214-e73d-4860-abf3-02e3bffd3837"), "Keyboard", false },
                    { new Guid("d017ef34-c572-484f-8f0e-db6895820e84"), "Monitor", false },
                    { new Guid("fad6955c-7d25-4656-ba26-c78b61f868b5"), "Headset", false }
                });

            migrationBuilder.InsertData(
                table: "Supplier",
                columns: new[] { "Id", "Name", "Removed" },
                values: new object[,]
                {
                    { new Guid("7f4c2666-36e8-4c00-aab7-934ff281a477"), "Supplier 2", false },
                    { new Guid("8ef6d8b1-94da-46aa-94ad-8ddc80c9543d"), "Supplier 1", false }
                });

            migrationBuilder.InsertData(
                table: "Warehouse",
                columns: new[] { "Id", "Address_City", "Address_PostalCode", "Address_Street", "Address_StreetNumber", "Name", "Removed" },
                values: new object[,]
                {
                    { new Guid("442317ac-de9b-4602-9265-189fbea591fb"), "Varberg", "43241", "Norrgatan", "13", "Warehouse 1", false },
                    { new Guid("8a85717a-9b54-4a7f-91d9-854df84d8a4b"), "Falkenberg", "31173", "Södergatan", "18", "Warehouse 2", false }
                });

            migrationBuilder.InsertData(
                table: "ProductSupplier",
                columns: new[] { "Id", "ProductId", "SupplierId" },
                values: new object[,]
                {
                    { new Guid("0be823cd-f299-44a6-8302-54672694ce00"), new Guid("fad6955c-7d25-4656-ba26-c78b61f868b5"), new Guid("8ef6d8b1-94da-46aa-94ad-8ddc80c9543d") },
                    { new Guid("99fef197-a862-48e8-90e8-6b675e625ef5"), new Guid("04462214-e73d-4860-abf3-02e3bffd3837"), new Guid("8ef6d8b1-94da-46aa-94ad-8ddc80c9543d") },
                    { new Guid("fa5126c2-7475-4664-a25c-c8afada544ac"), new Guid("d017ef34-c572-484f-8f0e-db6895820e84"), new Guid("7f4c2666-36e8-4c00-aab7-934ff281a477") }
                });

            migrationBuilder.InsertData(
                table: "StockItem",
                columns: new[] { "Id", "ProductId", "Quantity", "SupplierId", "WarehouseId" },
                values: new object[,]
                {
                    { new Guid("3fa367b4-77b8-46dd-837e-e83241fd5cef"), new Guid("fad6955c-7d25-4656-ba26-c78b61f868b5"), 200, new Guid("8ef6d8b1-94da-46aa-94ad-8ddc80c9543d"), new Guid("8a85717a-9b54-4a7f-91d9-854df84d8a4b") },
                    { new Guid("4ab7a9f1-680c-41cd-a3c8-af6d5f563b88"), new Guid("fad6955c-7d25-4656-ba26-c78b61f868b5"), 50, new Guid("8ef6d8b1-94da-46aa-94ad-8ddc80c9543d"), new Guid("442317ac-de9b-4602-9265-189fbea591fb") },
                    { new Guid("57a6d129-8347-4087-ad1e-6874f0672ad8"), new Guid("d017ef34-c572-484f-8f0e-db6895820e84"), 200, new Guid("7f4c2666-36e8-4c00-aab7-934ff281a477"), new Guid("8a85717a-9b54-4a7f-91d9-854df84d8a4b") },
                    { new Guid("6d2a47e4-9517-4a64-8e5c-2e5e762bd3d5"), new Guid("04462214-e73d-4860-abf3-02e3bffd3837"), 40, new Guid("8ef6d8b1-94da-46aa-94ad-8ddc80c9543d"), new Guid("442317ac-de9b-4602-9265-189fbea591fb") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductSupplier",
                keyColumn: "Id",
                keyValue: new Guid("0be823cd-f299-44a6-8302-54672694ce00"));

            migrationBuilder.DeleteData(
                table: "ProductSupplier",
                keyColumn: "Id",
                keyValue: new Guid("99fef197-a862-48e8-90e8-6b675e625ef5"));

            migrationBuilder.DeleteData(
                table: "ProductSupplier",
                keyColumn: "Id",
                keyValue: new Guid("fa5126c2-7475-4664-a25c-c8afada544ac"));

            migrationBuilder.DeleteData(
                table: "StockItem",
                keyColumn: "Id",
                keyValue: new Guid("3fa367b4-77b8-46dd-837e-e83241fd5cef"));

            migrationBuilder.DeleteData(
                table: "StockItem",
                keyColumn: "Id",
                keyValue: new Guid("4ab7a9f1-680c-41cd-a3c8-af6d5f563b88"));

            migrationBuilder.DeleteData(
                table: "StockItem",
                keyColumn: "Id",
                keyValue: new Guid("57a6d129-8347-4087-ad1e-6874f0672ad8"));

            migrationBuilder.DeleteData(
                table: "StockItem",
                keyColumn: "Id",
                keyValue: new Guid("6d2a47e4-9517-4a64-8e5c-2e5e762bd3d5"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("04462214-e73d-4860-abf3-02e3bffd3837"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("d017ef34-c572-484f-8f0e-db6895820e84"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("fad6955c-7d25-4656-ba26-c78b61f868b5"));

            migrationBuilder.DeleteData(
                table: "Supplier",
                keyColumn: "Id",
                keyValue: new Guid("7f4c2666-36e8-4c00-aab7-934ff281a477"));

            migrationBuilder.DeleteData(
                table: "Supplier",
                keyColumn: "Id",
                keyValue: new Guid("8ef6d8b1-94da-46aa-94ad-8ddc80c9543d"));

            migrationBuilder.DeleteData(
                table: "Warehouse",
                keyColumn: "Id",
                keyValue: new Guid("442317ac-de9b-4602-9265-189fbea591fb"));

            migrationBuilder.DeleteData(
                table: "Warehouse",
                keyColumn: "Id",
                keyValue: new Guid("8a85717a-9b54-4a7f-91d9-854df84d8a4b"));
        }
    }
}
