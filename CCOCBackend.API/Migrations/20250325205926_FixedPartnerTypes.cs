using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CCOCBackend.API.Migrations
{
    /// <inheritdoc />
    public partial class FixedPartnerTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartnerTypes_Partners_PartnerId",
                table: "PartnerTypes");

            migrationBuilder.DropIndex(
                name: "IX_PartnerTypes_PartnerId",
                table: "PartnerTypes");

            migrationBuilder.DropColumn(
                name: "PartnerId",
                table: "PartnerTypes");

            migrationBuilder.AddColumn<string>(
                name: "TypeId",
                table: "Partners",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Partners_TypeId",
                table: "Partners",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Partners_PartnerTypes_TypeId",
                table: "Partners",
                column: "TypeId",
                principalTable: "PartnerTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partners_PartnerTypes_TypeId",
                table: "Partners");

            migrationBuilder.DropIndex(
                name: "IX_Partners_TypeId",
                table: "Partners");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Partners");

            migrationBuilder.AddColumn<string>(
                name: "PartnerId",
                table: "PartnerTypes",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PartnerTypes_PartnerId",
                table: "PartnerTypes",
                column: "PartnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_PartnerTypes_Partners_PartnerId",
                table: "PartnerTypes",
                column: "PartnerId",
                principalTable: "Partners",
                principalColumn: "Id");
        }
    }
}
