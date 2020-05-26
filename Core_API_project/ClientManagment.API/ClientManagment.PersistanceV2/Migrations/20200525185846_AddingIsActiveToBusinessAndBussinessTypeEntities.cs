using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientManagment.PersistanceV2.Migrations
{
    public partial class AddingIsActiveToBusinessAndBussinessTypeEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "35fa9a3c-98f2-4b87-a52c-a6fd04e24eee");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "534bfd39-0bea-4c0a-a1f7-5785ebfb9f87");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "8bcca83e-7897-4e17-ad6c-9e3fea8262df");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "BusinessTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Business",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "BusinessTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ccf7f071-0468-45f1-9215-c3aa5fce53f2", "0e977141-5081-421b-9fc2-01e1add8e0f5", "Admin", "ADMIN" },
                    { "07f3df1e-d6d3-474f-9af8-7b7a31e5c75d", "477d91eb-a065-4ae7-bf6a-3caaf467c8e5", "User", "USER" },
                    { "0efefad8-e1d9-4f83-a4ec-8dbc3fd818c5", "81377bd8-10b2-47b8-8c00-6a9e9e6a47e4", "Businessmen", "BUSINESSMEN" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "BusinessTypes");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Business");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "35fa9a3c-98f2-4b87-a52c-a6fd04e24eee", "1e401751-bd4b-4fa6-860f-bf71fff1c335", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8bcca83e-7897-4e17-ad6c-9e3fea8262df", "b85445ae-3849-44f0-883e-9f3a3b16a8b8", "User", "USER" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "534bfd39-0bea-4c0a-a1f7-5785ebfb9f87", "10ed25cd-cf69-4950-980a-b1d56ecd9716", "Businessmen", "BUSINESSMEN" });
        }
    }
}
