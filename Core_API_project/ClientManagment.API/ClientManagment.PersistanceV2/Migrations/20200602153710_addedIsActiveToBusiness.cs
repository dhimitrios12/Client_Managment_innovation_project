using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientManagment.PersistanceV2.Migrations
{
    public partial class addedIsActiveToBusiness : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "07f3df1e-d6d3-474f-9af8-7b7a31e5c75d");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "0efefad8-e1d9-4f83-a4ec-8dbc3fd818c5");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "ccf7f071-0468-45f1-9215-c3aa5fce53f2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ccf7f071-0468-45f1-9215-c3aa5fce53f2", "0e977141-5081-421b-9fc2-01e1add8e0f5", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "07f3df1e-d6d3-474f-9af8-7b7a31e5c75d", "477d91eb-a065-4ae7-bf6a-3caaf467c8e5", "User", "USER" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0efefad8-e1d9-4f83-a4ec-8dbc3fd818c5", "81377bd8-10b2-47b8-8c00-6a9e9e6a47e4", "Businessmen", "BUSINESSMEN" });
        }
    }
}
