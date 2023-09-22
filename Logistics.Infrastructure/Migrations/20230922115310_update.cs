using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Logistics.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "SupplierId",
                table: "History",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Name", "Removed" },
                values: new object[,]
                {
                    { new Guid("0a616438-9c96-44e3-b5fe-e318e0383c79"), "Headset", false },
                    { new Guid("3eeabad7-ae68-45d2-bfc3-beba17ce9efa"), "Keyboard", false },
                    { new Guid("af02a16a-87a3-49e3-a6da-f16e44c5cce3"), "Monitor", false }
                });

            migrationBuilder.InsertData(
                table: "Supplier",
                columns: new[] { "Id", "Name", "Removed" },
                values: new object[,]
                {
                    { new Guid("4c9a025b-1581-46dc-a982-f347b2cff27d"), "Supplier 2", false },
                    { new Guid("9dae6a9e-f112-406c-bf2e-31874a24baa3"), "Supplier 1", false }
                });

            migrationBuilder.InsertData(
                table: "Warehouse",
                columns: new[] { "Id", "Address_City", "Address_PostalCode", "Address_Street", "Address_StreetNumber", "Name", "Removed" },
                values: new object[,]
                {
                    { new Guid("21590c7c-2483-4d3a-9cd9-3505c2aa988e"), "Varberg", "43236", "Föreningsgatan", "56", "Warehouse 2", false },
                    { new Guid("bf9288d0-48ef-43ae-b86a-f516d5583937"), "Varberg", "43237", "Träslövsvägen", "171G", "Warehouse 1", false }
                });

            migrationBuilder.InsertData(
                table: "ProductSupplier",
                columns: new[] { "Id", "ProductId", "SupplierId" },
                values: new object[,]
                {
                    { new Guid("3a0dc838-8a43-4c52-ab71-082583eeee0e"), new Guid("af02a16a-87a3-49e3-a6da-f16e44c5cce3"), new Guid("4c9a025b-1581-46dc-a982-f347b2cff27d") },
                    { new Guid("56c8b90a-64f7-4483-99db-8f00f22a5f3d"), new Guid("3eeabad7-ae68-45d2-bfc3-beba17ce9efa"), new Guid("9dae6a9e-f112-406c-bf2e-31874a24baa3") },
                    { new Guid("9a72106e-0a6e-4b4e-92bd-061425299dca"), new Guid("0a616438-9c96-44e3-b5fe-e318e0383c79"), new Guid("9dae6a9e-f112-406c-bf2e-31874a24baa3") }
                });

            migrationBuilder.InsertData(
                table: "StockItem",
                columns: new[] { "Id", "ProductId", "Quantity", "SupplierId", "WarehouseId" },
                values: new object[,]
                {
                    { new Guid("9c36786a-e924-4dbd-97b1-3b9a1bfb6458"), new Guid("0a616438-9c96-44e3-b5fe-e318e0383c79"), 50, new Guid("9dae6a9e-f112-406c-bf2e-31874a24baa3"), new Guid("bf9288d0-48ef-43ae-b86a-f516d5583937") },
                    { new Guid("aab30ddb-4da9-440d-a7fb-817194a28e2c"), new Guid("af02a16a-87a3-49e3-a6da-f16e44c5cce3"), 200, new Guid("4c9a025b-1581-46dc-a982-f347b2cff27d"), new Guid("21590c7c-2483-4d3a-9cd9-3505c2aa988e") },
                    { new Guid("cff55678-1d84-4852-928e-ba5104196173"), new Guid("3eeabad7-ae68-45d2-bfc3-beba17ce9efa"), 40, new Guid("9dae6a9e-f112-406c-bf2e-31874a24baa3"), new Guid("bf9288d0-48ef-43ae-b86a-f516d5583937") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductSupplier",
                keyColumn: "Id",
                keyValue: new Guid("3a0dc838-8a43-4c52-ab71-082583eeee0e"));

            migrationBuilder.DeleteData(
                table: "ProductSupplier",
                keyColumn: "Id",
                keyValue: new Guid("56c8b90a-64f7-4483-99db-8f00f22a5f3d"));

            migrationBuilder.DeleteData(
                table: "ProductSupplier",
                keyColumn: "Id",
                keyValue: new Guid("9a72106e-0a6e-4b4e-92bd-061425299dca"));

            migrationBuilder.DeleteData(
                table: "StockItem",
                keyColumn: "Id",
                keyValue: new Guid("9c36786a-e924-4dbd-97b1-3b9a1bfb6458"));

            migrationBuilder.DeleteData(
                table: "StockItem",
                keyColumn: "Id",
                keyValue: new Guid("aab30ddb-4da9-440d-a7fb-817194a28e2c"));

            migrationBuilder.DeleteData(
                table: "StockItem",
                keyColumn: "Id",
                keyValue: new Guid("cff55678-1d84-4852-928e-ba5104196173"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("0a616438-9c96-44e3-b5fe-e318e0383c79"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("3eeabad7-ae68-45d2-bfc3-beba17ce9efa"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("af02a16a-87a3-49e3-a6da-f16e44c5cce3"));

            migrationBuilder.DeleteData(
                table: "Supplier",
                keyColumn: "Id",
                keyValue: new Guid("4c9a025b-1581-46dc-a982-f347b2cff27d"));

            migrationBuilder.DeleteData(
                table: "Supplier",
                keyColumn: "Id",
                keyValue: new Guid("9dae6a9e-f112-406c-bf2e-31874a24baa3"));

            migrationBuilder.DeleteData(
                table: "Warehouse",
                keyColumn: "Id",
                keyValue: new Guid("21590c7c-2483-4d3a-9cd9-3505c2aa988e"));

            migrationBuilder.DeleteData(
                table: "Warehouse",
                keyColumn: "Id",
                keyValue: new Guid("bf9288d0-48ef-43ae-b86a-f516d5583937"));

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "History");

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
                columns: new[] { "Id", "Name", "Removed", "Address_City", "Address_PostalCode", "Address_Street", "Address_StreetNumber" },
                values: new object[,]
                {
                    { new Guid("ed457b5d-5c74-45d0-b42f-2fb8dd3a5b95"), "Warehouse 1", false, "Varberg", "43237", "Träslövsvägen", "171G" },
                    { new Guid("f9168bfb-e93e-47ba-8b9e-8f77cb469a6f"), "Warehouse 2", false, "Varberg", "43236", "Föreningsgatan", "56" }
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
    }
}
