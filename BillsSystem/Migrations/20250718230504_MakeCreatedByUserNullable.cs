using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BillsSystem.Migrations
{
    /// <inheritdoc />
    public partial class MakeCreatedByUserNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_ApplicationUser_CreatedByUserId",
                table: "Bills");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByUserId",
                table: "Bills",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_ApplicationUser_CreatedByUserId",
                table: "Bills",
                column: "CreatedByUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_ApplicationUser_CreatedByUserId",
                table: "Bills");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByUserId",
                table: "Bills",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_ApplicationUser_CreatedByUserId",
                table: "Bills",
                column: "CreatedByUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
