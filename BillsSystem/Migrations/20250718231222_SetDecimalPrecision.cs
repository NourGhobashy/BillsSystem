using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BillsSystem.Migrations
{
    /// <inheritdoc />
    public partial class SetDecimalPrecision : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillItem_Bills_BillId",
                table: "BillItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BillItem",
                table: "BillItem");

            migrationBuilder.RenameTable(
                name: "BillItem",
                newName: "BillItems");

            migrationBuilder.RenameIndex(
                name: "IX_BillItem_BillId",
                table: "BillItems",
                newName: "IX_BillItems_BillId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BillItems",
                table: "BillItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BillItems_Bills_BillId",
                table: "BillItems",
                column: "BillId",
                principalTable: "Bills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillItems_Bills_BillId",
                table: "BillItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BillItems",
                table: "BillItems");

            migrationBuilder.RenameTable(
                name: "BillItems",
                newName: "BillItem");

            migrationBuilder.RenameIndex(
                name: "IX_BillItems_BillId",
                table: "BillItem",
                newName: "IX_BillItem_BillId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BillItem",
                table: "BillItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BillItem_Bills_BillId",
                table: "BillItem",
                column: "BillId",
                principalTable: "Bills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
