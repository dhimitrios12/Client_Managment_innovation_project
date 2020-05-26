using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientManagment.PersistanceV2.Migrations
{
    public partial class AddingBusinesstypeSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "49d139e5-af20-475f-954b-ff93e1d594bc");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "4ab6dc78-38c7-4d1d-afac-6d9a0c022b86");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "7a054ff6-2d33-4622-b52f-4dda930fdf75");

            migrationBuilder.InsertData(
                table: "BusinessTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Berber" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b0fb599c-424d-4ddd-a726-f8f93f9b76c5", "0974fbb0-9ae6-489d-ba57-09a92279ba83", "Admin", "ADMIN" },
                    { "45197263-267e-4403-b161-0ed932100f5b", "7b4ec936-a7e1-4306-b837-52b878edfc14", "User", "USER" },
                    { "7cfa7b9d-99ea-4d2a-90ea-f1966270fddf", "c442e73f-b944-4b44-b1bb-7eb2645797c7", "Businessmen", "BUSINESSMEN" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BusinessTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "45197263-267e-4403-b161-0ed932100f5b");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "7cfa7b9d-99ea-4d2a-90ea-f1966270fddf");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "b0fb599c-424d-4ddd-a726-f8f93f9b76c5");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7a054ff6-2d33-4622-b52f-4dda930fdf75", "5ec798fc-5461-4386-ace3-d79da2440dff", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4ab6dc78-38c7-4d1d-afac-6d9a0c022b86", "f6652ab9-5df9-4a54-81cb-e1f9522bd7ee", "User", "USER" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "49d139e5-af20-475f-954b-ff93e1d594bc", "11d4375d-f7e4-4644-a46d-3742fb845e24", "Businessmen", "BUSINESSMEN" });
        }
    }
}
