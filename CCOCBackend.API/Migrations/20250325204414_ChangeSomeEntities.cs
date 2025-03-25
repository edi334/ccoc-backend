using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CCOCBackend.API.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSomeEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PartnerType",
                table: "Partners");

            migrationBuilder.CreateTable(
                name: "PageImages",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ImageId = table.Column<string>(type: "text", nullable: true),
                    PageId = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PageImages_Files_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Files",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PageImages_Pages_PageId",
                        column: x => x.PageId,
                        principalTable: "Pages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PartnerTypes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    PartnerId = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartnerTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartnerTypes_Partners_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Partners",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PageImages_Created",
                table: "PageImages",
                column: "Created");

            migrationBuilder.CreateIndex(
                name: "IX_PageImages_ImageId",
                table: "PageImages",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_PageImages_PageId",
                table: "PageImages",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_PageImages_Updated",
                table: "PageImages",
                column: "Updated");

            migrationBuilder.CreateIndex(
                name: "IX_PartnerTypes_Created",
                table: "PartnerTypes",
                column: "Created");

            migrationBuilder.CreateIndex(
                name: "IX_PartnerTypes_PartnerId",
                table: "PartnerTypes",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_PartnerTypes_Updated",
                table: "PartnerTypes",
                column: "Updated");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PageImages");

            migrationBuilder.DropTable(
                name: "PartnerTypes");

            migrationBuilder.AddColumn<int>(
                name: "PartnerType",
                table: "Partners",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
