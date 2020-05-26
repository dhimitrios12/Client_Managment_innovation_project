using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientManagment.PersistanceV2.Migrations
{
    public partial class AddingBusinessEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Business",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 150, nullable: false),
                    Address = table.Column<string>(maxLength: 500, nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    FinishTime = table.Column<DateTime>(nullable: false),
                    BusinessTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Business", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Business_BusinessTypes_BusinessTypeId",
                        column: x => x.BusinessTypeId,
                        principalTable: "BusinessTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Business_BusinessTypeId",
                table: "Business",
                column: "BusinessTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Business");

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

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b0fb599c-424d-4ddd-a726-f8f93f9b76c5", "0974fbb0-9ae6-489d-ba57-09a92279ba83", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "45197263-267e-4403-b161-0ed932100f5b", "7b4ec936-a7e1-4306-b837-52b878edfc14", "User", "USER" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7cfa7b9d-99ea-4d2a-90ea-f1966270fddf", "c442e73f-b944-4b44-b1bb-7eb2645797c7", "Businessmen", "BUSINESSMEN" });
        }
    }
}
