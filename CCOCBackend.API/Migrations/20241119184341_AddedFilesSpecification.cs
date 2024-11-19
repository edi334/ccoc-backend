using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CCOCBackend.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedFilesSpecification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Files_Created",
                table: "Files",
                column: "Created");

            migrationBuilder.CreateIndex(
                name: "IX_Files_Updated",
                table: "Files",
                column: "Updated");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Files_Created",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_Updated",
                table: "Files");
        }
    }
}
