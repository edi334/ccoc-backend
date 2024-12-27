using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CCOCBackend.API.Migrations
{
    /// <inheritdoc />
    public partial class RenamePTagsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonTags_Person Tags_PTagId",
                table: "PersonTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Person Tags",
                table: "Person Tags");

            migrationBuilder.RenameTable(
                name: "Person Tags",
                newName: "PTags");

            migrationBuilder.RenameIndex(
                name: "IX_Person Tags_Updated",
                table: "PTags",
                newName: "IX_PTags_Updated");

            migrationBuilder.RenameIndex(
                name: "IX_Person Tags_Created",
                table: "PTags",
                newName: "IX_PTags_Created");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PTags",
                table: "PTags",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonTags_PTags_PTagId",
                table: "PersonTags",
                column: "PTagId",
                principalTable: "PTags",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonTags_PTags_PTagId",
                table: "PersonTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PTags",
                table: "PTags");

            migrationBuilder.RenameTable(
                name: "PTags",
                newName: "Person Tags");

            migrationBuilder.RenameIndex(
                name: "IX_PTags_Updated",
                table: "Person Tags",
                newName: "IX_Person Tags_Updated");

            migrationBuilder.RenameIndex(
                name: "IX_PTags_Created",
                table: "Person Tags",
                newName: "IX_Person Tags_Created");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Person Tags",
                table: "Person Tags",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonTags_Person Tags_PTagId",
                table: "PersonTags",
                column: "PTagId",
                principalTable: "Person Tags",
                principalColumn: "Id");
        }
    }
}
