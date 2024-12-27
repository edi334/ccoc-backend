using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CCOCBackend.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedPTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "People");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "People",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Person Tags",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonTags",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    PersonId = table.Column<string>(type: "text", nullable: true),
                    PTagId = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonTags_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PersonTags_Person Tags_PTagId",
                        column: x => x.PTagId,
                        principalTable: "Person Tags",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Person Tags_Created",
                table: "Person Tags",
                column: "Created");

            migrationBuilder.CreateIndex(
                name: "IX_Person Tags_Updated",
                table: "Person Tags",
                column: "Updated");

            migrationBuilder.CreateIndex(
                name: "IX_PersonTags_Created",
                table: "PersonTags",
                column: "Created");

            migrationBuilder.CreateIndex(
                name: "IX_PersonTags_PTagId",
                table: "PersonTags",
                column: "PTagId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonTags_PersonId",
                table: "PersonTags",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonTags_Updated",
                table: "PersonTags",
                column: "Updated");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonTags");

            migrationBuilder.DropTable(
                name: "Person Tags");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "People");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "People",
                type: "text",
                nullable: true);
        }
    }
}
