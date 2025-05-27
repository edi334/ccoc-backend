using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CCOCBackend.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedProjectParents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectEditions");

            migrationBuilder.AddColumn<bool>(
                name: "IsParent",
                table: "Projects",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ParentId",
                table: "Projects",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ParentId",
                table: "Projects",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Projects_ParentId",
                table: "Projects",
                column: "ParentId",
                principalTable: "Projects",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Projects_ParentId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ParentId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "IsParent",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Projects");

            migrationBuilder.CreateTable(
                name: "ProjectEditions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ProjectId = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectEditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectEditions_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEditions_Created",
                table: "ProjectEditions",
                column: "Created");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEditions_ProjectId",
                table: "ProjectEditions",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEditions_Updated",
                table: "ProjectEditions",
                column: "Updated");
        }
    }
}
