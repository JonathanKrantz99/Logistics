using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Logistics.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seed2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Name", "Removed" },
                values: new object[,]
                {
                    { new Guid("23e41087-be50-413f-ab72-8a954ea17bb3"), "Monitor", false },
                    { new Guid("46c56425-59b8-4e67-9324-ebf421da469c"), "Keyboard", false },
                    { new Guid("f3774ff3-9571-47d5-aae4-628a993ef0e9"), "Headset", false }
                });

            migrationBuilder.InsertData(
                table: "Supplier",
                columns: new[] { "Id", "Name", "Removed" },
                values: new object[,]
                {
                    { new Guid("25d5cfc4-82ef-42d3-801a-57be4d45f9be"), "Supplier 2", false },
                    { new Guid("2f8fdd19-ff67-4cf9-b0b9-15d6ab6fc517"), "Supplier 1", false }
                });

            migrationBuilder.InsertData(
                table: "Warehouse",
                columns: new[] { "Id", "Address_City", "Address_PostalCode", "Address_Street", "Address_StreetNumber", "Name", "Removed" },
                values: new object[,]
                {
                    { new Guid("0cb6cf65-2e3c-4717-b66b-174606c7ca73"), "Varberg", "43236", "Föreningsgatan", "56", "Warehouse 2", false },
                    { new Guid("7e86d0c3-dee7-4ad2-b628-c09029b0a9a8"), "Varberg", "43237", "Träslövsvägen", "171G", "Warehouse 1", false }
                });

            migrationBuilder.InsertData(
                table: "ProductSupplier",
                columns: new[] { "Id", "ProductId", "SupplierId" },
                values: new object[,]
                {
                    { new Guid("07be344f-d923-47f3-a1be-9c22291898db"), new Guid("23e41087-be50-413f-ab72-8a954ea17bb3"), new Guid("25d5cfc4-82ef-42d3-801a-57be4d45f9be") },
                    { new Guid("9039d8bb-ca27-42ac-b804-f29a7cb05271"), new Guid("46c56425-59b8-4e67-9324-ebf421da469c"), new Guid("2f8fdd19-ff67-4cf9-b0b9-15d6ab6fc517") },
                    { new Guid("a52e2e70-c0b8-49f2-832a-6e2936152159"), new Guid("f3774ff3-9571-47d5-aae4-628a993ef0e9"), new Guid("2f8fdd19-ff67-4cf9-b0b9-15d6ab6fc517") }
                });

            migrationBuilder.InsertData(
                table: "StockItem",
                columns: new[] { "Id", "ProductId", "Quantity", "SupplierId", "WarehouseId" },
                values: new object[,]
                {
                    { new Guid("04d46ce6-2524-456d-a22f-4e0875cf82d5"), new Guid("46c56425-59b8-4e67-9324-ebf421da469c"), 40, new Guid("2f8fdd19-ff67-4cf9-b0b9-15d6ab6fc517"), new Guid("7e86d0c3-dee7-4ad2-b628-c09029b0a9a8") },
                    { new Guid("582e4bb0-117a-4864-85de-ea757d39011a"), new Guid("23e41087-be50-413f-ab72-8a954ea17bb3"), 200, new Guid("25d5cfc4-82ef-42d3-801a-57be4d45f9be"), new Guid("0cb6cf65-2e3c-4717-b66b-174606c7ca73") },
                    { new Guid("efdbda66-84e3-446d-a5de-806a2242a806"), new Guid("f3774ff3-9571-47d5-aae4-628a993ef0e9"), 50, new Guid("2f8fdd19-ff67-4cf9-b0b9-15d6ab6fc517"), new Guid("7e86d0c3-dee7-4ad2-b628-c09029b0a9a8") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductSupplier",
                keyColumn: "Id",
                keyValue: new Guid("07be344f-d923-47f3-a1be-9c22291898db"));

            migrationBuilder.DeleteData(
                table: "ProductSupplier",
                keyColumn: "Id",
                keyValue: new Guid("9039d8bb-ca27-42ac-b804-f29a7cb05271"));

            migrationBuilder.DeleteData(
                table: "ProductSupplier",
                keyColumn: "Id",
                keyValue: new Guid("a52e2e70-c0b8-49f2-832a-6e2936152159"));

            migrationBuilder.DeleteData(
                table: "StockItem",
                keyColumn: "Id",
                keyValue: new Guid("04d46ce6-2524-456d-a22f-4e0875cf82d5"));

            migrationBuilder.DeleteData(
                table: "StockItem",
                keyColumn: "Id",
                keyValue: new Guid("582e4bb0-117a-4864-85de-ea757d39011a"));

            migrationBuilder.DeleteData(
                table: "StockItem",
                keyColumn: "Id",
                keyValue: new Guid("efdbda66-84e3-446d-a5de-806a2242a806"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("23e41087-be50-413f-ab72-8a954ea17bb3"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("46c56425-59b8-4e67-9324-ebf421da469c"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("f3774ff3-9571-47d5-aae4-628a993ef0e9"));

            migrationBuilder.DeleteData(
                table: "Supplier",
                keyColumn: "Id",
                keyValue: new Guid("25d5cfc4-82ef-42d3-801a-57be4d45f9be"));

            migrationBuilder.DeleteData(
                table: "Supplier",
                keyColumn: "Id",
                keyValue: new Guid("2f8fdd19-ff67-4cf9-b0b9-15d6ab6fc517"));

            migrationBuilder.DeleteData(
                table: "Warehouse",
                keyColumn: "Id",
                keyValue: new Guid("0cb6cf65-2e3c-4717-b66b-174606c7ca73"));

            migrationBuilder.DeleteData(
                table: "Warehouse",
                keyColumn: "Id",
                keyValue: new Guid("7e86d0c3-dee7-4ad2-b628-c09029b0a9a8"));

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
                columns: new[] { "Id", "Name", "Removed", "Address_City", "Address_PostalCode", "Address_Street", "Address_StreetNumber" },
                values: new object[,]
                {
                    { new Guid("21590c7c-2483-4d3a-9cd9-3505c2aa988e"), "Warehouse 2", false, "Varberg", "43236", "Föreningsgatan", "56" },
                    { new Guid("bf9288d0-48ef-43ae-b86a-f516d5583937"), "Warehouse 1", false, "Varberg", "43237", "Träslövsvägen", "171G" }
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
    }
}
