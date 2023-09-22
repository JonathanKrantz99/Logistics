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
                    { new Guid("4e9f971b-9879-4ed2-9f8e-1af456a43009"), "Monitor", false },
                    { new Guid("66e2f931-da68-4c09-a585-2792d51e887e"), "Headset", false },
                    { new Guid("6fce5b91-659b-47fd-af97-9c5225ed3b46"), "Keyboard", false }
                });

            migrationBuilder.InsertData(
                table: "Supplier",
                columns: new[] { "Id", "Name", "Removed" },
                values: new object[,]
                {
                    { new Guid("24ac99ee-2f39-4ee8-a18a-3e48e1afb36a"), "Supplier 2", false },
                    { new Guid("4998a0d0-a2a9-4b13-b259-e5b29204a96a"), "Supplier 1", false }
                });

            migrationBuilder.InsertData(
                table: "Warehouse",
                columns: new[] { "Id", "Address_City", "Address_PostalCode", "Address_Street", "Address_StreetNumber", "Name", "Removed" },
                values: new object[,]
                {
                    { new Guid("ed457b5d-5c74-45d0-b42f-2fb8dd3a5b95"), "Varberg", "43237", "Träslövsvägen", "171G", "Warehouse 1", false },
                    { new Guid("f9168bfb-e93e-47ba-8b9e-8f77cb469a6f"), "Varberg", "43236", "Föreningsgatan", "56", "Warehouse 2", false }
                });

            migrationBuilder.InsertData(
                table: "ProductSupplier",
                columns: new[] { "Id", "ProductId", "SupplierId" },
                values: new object[,]
                {
                    { new Guid("6c43d9a5-ff99-40fb-ae8d-453f3d8a26a5"), new Guid("4e9f971b-9879-4ed2-9f8e-1af456a43009"), new Guid("24ac99ee-2f39-4ee8-a18a-3e48e1afb36a") },
                    { new Guid("a78dd8b0-23e6-481f-9b55-57633838b094"), new Guid("6fce5b91-659b-47fd-af97-9c5225ed3b46"), new Guid("4998a0d0-a2a9-4b13-b259-e5b29204a96a") },
                    { new Guid("e6fa28ed-65cc-423d-a689-5f968e7468c5"), new Guid("66e2f931-da68-4c09-a585-2792d51e887e"), new Guid("4998a0d0-a2a9-4b13-b259-e5b29204a96a") }
                });

            migrationBuilder.InsertData(
                table: "StockItem",
                columns: new[] { "Id", "ProductId", "Quantity", "SupplierId", "WarehouseId" },
                values: new object[,]
                {
                    { new Guid("42e578b5-3d92-44d2-a97a-d34a04b6120f"), new Guid("4e9f971b-9879-4ed2-9f8e-1af456a43009"), 200, new Guid("24ac99ee-2f39-4ee8-a18a-3e48e1afb36a"), new Guid("f9168bfb-e93e-47ba-8b9e-8f77cb469a6f") },
                    { new Guid("81cb7e5c-3bf6-4e74-b60a-130fb37c4767"), new Guid("6fce5b91-659b-47fd-af97-9c5225ed3b46"), 40, new Guid("4998a0d0-a2a9-4b13-b259-e5b29204a96a"), new Guid("ed457b5d-5c74-45d0-b42f-2fb8dd3a5b95") },
                    { new Guid("8929b33c-18d1-4b4e-b158-ca2a25ce7229"), new Guid("66e2f931-da68-4c09-a585-2792d51e887e"), 50, new Guid("4998a0d0-a2a9-4b13-b259-e5b29204a96a"), new Guid("ed457b5d-5c74-45d0-b42f-2fb8dd3a5b95") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductSupplier",
                keyColumn: "Id",
                keyValue: new Guid("6c43d9a5-ff99-40fb-ae8d-453f3d8a26a5"));

            migrationBuilder.DeleteData(
                table: "ProductSupplier",
                keyColumn: "Id",
                keyValue: new Guid("a78dd8b0-23e6-481f-9b55-57633838b094"));

            migrationBuilder.DeleteData(
                table: "ProductSupplier",
                keyColumn: "Id",
                keyValue: new Guid("e6fa28ed-65cc-423d-a689-5f968e7468c5"));

            migrationBuilder.DeleteData(
                table: "StockItem",
                keyColumn: "Id",
                keyValue: new Guid("42e578b5-3d92-44d2-a97a-d34a04b6120f"));

            migrationBuilder.DeleteData(
                table: "StockItem",
                keyColumn: "Id",
                keyValue: new Guid("81cb7e5c-3bf6-4e74-b60a-130fb37c4767"));

            migrationBuilder.DeleteData(
                table: "StockItem",
                keyColumn: "Id",
                keyValue: new Guid("8929b33c-18d1-4b4e-b158-ca2a25ce7229"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("4e9f971b-9879-4ed2-9f8e-1af456a43009"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("66e2f931-da68-4c09-a585-2792d51e887e"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("6fce5b91-659b-47fd-af97-9c5225ed3b46"));

            migrationBuilder.DeleteData(
                table: "Supplier",
                keyColumn: "Id",
                keyValue: new Guid("24ac99ee-2f39-4ee8-a18a-3e48e1afb36a"));

            migrationBuilder.DeleteData(
                table: "Supplier",
                keyColumn: "Id",
                keyValue: new Guid("4998a0d0-a2a9-4b13-b259-e5b29204a96a"));

            migrationBuilder.DeleteData(
                table: "Warehouse",
                keyColumn: "Id",
                keyValue: new Guid("ed457b5d-5c74-45d0-b42f-2fb8dd3a5b95"));

            migrationBuilder.DeleteData(
                table: "Warehouse",
                keyColumn: "Id",
                keyValue: new Guid("f9168bfb-e93e-47ba-8b9e-8f77cb469a6f"));
        }
    }
}
