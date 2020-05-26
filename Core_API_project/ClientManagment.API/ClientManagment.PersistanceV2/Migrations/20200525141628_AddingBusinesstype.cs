using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientManagment.PersistanceV2.Migrations
{
    public partial class AddingBusinesstype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "BusinessTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessTypes", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessTypes");

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
    }
}
