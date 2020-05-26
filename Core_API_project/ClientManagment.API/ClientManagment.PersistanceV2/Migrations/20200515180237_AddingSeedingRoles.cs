using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientManagment.PersistanceV2.Migrations
{
    public partial class AddingSeedingRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "8603e58d-b2c8-4a54-a5a3-4c5276698b5e");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "da1682a4-d33f-4dd6-8417-4e097db66aba");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "e52116f4-5434-4222-a7f8-ec59a51bd56c");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1d6bcb8a-c1db-423d-99b3-d791935d58c8", "0a3295a7-1635-47f7-bec0-a0e188d148fc", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7202c341-21b1-492c-b034-4cb74af42ec7", "52294d30-6b8f-4870-83b0-d23744712d33", "User", "USER" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "066e929f-955b-49d9-af10-180d33aca9ed", "e3335a91-6a5b-409a-adf4-38637b81d359", "Businessmen", "BUSINESSMEN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "066e929f-955b-49d9-af10-180d33aca9ed");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1d6bcb8a-c1db-423d-99b3-d791935d58c8");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "7202c341-21b1-492c-b034-4cb74af42ec7");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "da1682a4-d33f-4dd6-8417-4e097db66aba", "d3157091-2c0a-4d46-9bd3-7ac6f4965fd8", "Admin", null });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8603e58d-b2c8-4a54-a5a3-4c5276698b5e", "14274c5d-36c0-4975-858b-f2462ab09dda", "User", null });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e52116f4-5434-4222-a7f8-ec59a51bd56c", "ffb3d474-200e-4120-b1a9-de954cabd932", "Businessmen", null });
        }
    }
}
