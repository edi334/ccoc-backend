using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CCOCBackend.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedSomeEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Projects",
                newName: "TitleImageId");

            migrationBuilder.AddColumn<string>(
                name: "FormLink",
                table: "Services",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageId",
                table: "Services",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PresentationImageId",
                table: "Projects",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Projects",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Projects",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Projects",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Services_ImageId",
                table: "Services",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_PresentationImageId",
                table: "Projects",
                column: "PresentationImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_TitleImageId",
                table: "Projects",
                column: "TitleImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Files_PresentationImageId",
                table: "Projects",
                column: "PresentationImageId",
                principalTable: "Files",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Files_TitleImageId",
                table: "Projects",
                column: "TitleImageId",
                principalTable: "Files",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Files_ImageId",
                table: "Services",
                column: "ImageId",
                principalTable: "Files",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Files_PresentationImageId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Files_TitleImageId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Files_ImageId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_ImageId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Projects_PresentationImageId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_TitleImageId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "FormLink",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "PresentationImageId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "TitleImageId",
                table: "Projects",
                newName: "Name");
        }
    }
}
