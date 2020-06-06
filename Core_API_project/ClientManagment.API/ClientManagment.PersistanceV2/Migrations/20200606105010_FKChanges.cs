using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientManagment.PersistanceV2.Migrations
{
    public partial class FKChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceRequest_Users_ClientId",
                table: "ServiceRequest");

            migrationBuilder.DropIndex(
                name: "IX_ServiceRequest_ClientId",
                table: "ServiceRequest");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "ServiceRequest");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ServiceRequest",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequest_UserId",
                table: "ServiceRequest",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceRequest_Users_UserId",
                table: "ServiceRequest",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceRequest_Users_UserId",
                table: "ServiceRequest");

            migrationBuilder.DropIndex(
                name: "IX_ServiceRequest_UserId",
                table: "ServiceRequest");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ServiceRequest",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "ClientId",
                table: "ServiceRequest",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequest_ClientId",
                table: "ServiceRequest",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceRequest_Users_ClientId",
                table: "ServiceRequest",
                column: "ClientId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
