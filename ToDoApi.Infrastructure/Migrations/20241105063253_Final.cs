using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Final : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_MiniAppUsers_MiniAppUserId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_MiniAppUserId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "MiniAppUserId",
                table: "Contacts");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_UserId",
                table: "Contacts",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_MiniAppUsers_UserId",
                table: "Contacts",
                column: "UserId",
                principalTable: "MiniAppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_MiniAppUsers_UserId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_UserId",
                table: "Contacts");

            migrationBuilder.AddColumn<long>(
                name: "MiniAppUserId",
                table: "Contacts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_MiniAppUserId",
                table: "Contacts",
                column: "MiniAppUserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_MiniAppUsers_MiniAppUserId",
                table: "Contacts",
                column: "MiniAppUserId",
                principalTable: "MiniAppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
