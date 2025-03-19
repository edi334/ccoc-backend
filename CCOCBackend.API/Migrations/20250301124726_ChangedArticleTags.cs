using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CCOCBackend.API.Migrations
{
    /// <inheritdoc />
    public partial class ChangedArticleTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Files_IconId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_IconId",
                table: "Tags");

            migrationBuilder.RenameColumn(
                name: "IconId",
                table: "Tags",
                newName: "HexColor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HexColor",
                table: "Tags",
                newName: "IconId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_IconId",
                table: "Tags",
                column: "IconId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Files_IconId",
                table: "Tags",
                column: "IconId",
                principalTable: "Files",
                principalColumn: "Id");
        }
    }
}
