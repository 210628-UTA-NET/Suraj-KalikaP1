using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreDL.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "LineItems");

            migrationBuilder.RenameColumn(
                name: "StoreId",
                table: "LineItems",
                newName: "StoreFrontId");

            migrationBuilder.CreateIndex(
                name: "IX_LineItems_ProductId",
                table: "LineItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_LineItems_StoreFrontId",
                table: "LineItems",
                column: "StoreFrontId");

            migrationBuilder.AddForeignKey(
                name: "FK_LineItems_Products_ProductId",
                table: "LineItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LineItems_StoreFronts_StoreFrontId",
                table: "LineItems",
                column: "StoreFrontId",
                principalTable: "StoreFronts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_Products_ProductId",
                table: "LineItems");

            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_StoreFronts_StoreFrontId",
                table: "LineItems");

            migrationBuilder.DropIndex(
                name: "IX_LineItems_ProductId",
                table: "LineItems");

            migrationBuilder.DropIndex(
                name: "IX_LineItems_StoreFrontId",
                table: "LineItems");

            migrationBuilder.RenameColumn(
                name: "StoreFrontId",
                table: "LineItems",
                newName: "StoreId");

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "LineItems",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
