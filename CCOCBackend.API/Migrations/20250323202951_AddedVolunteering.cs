using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CCOCBackend.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedVolunteering : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "Pages",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Volunteerings",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Text = table.Column<string>(type: "text", nullable: true),
                    LinkTo = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volunteerings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VolunteeringBenefits",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ImageId = table.Column<string>(type: "text", nullable: true),
                    VolunteeringId = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VolunteeringBenefits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VolunteeringBenefits_Files_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Files",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VolunteeringBenefits_Volunteerings_VolunteeringId",
                        column: x => x.VolunteeringId,
                        principalTable: "Volunteerings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VolunteeringCarouselPages",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Enabled = table.Column<bool>(type: "boolean", nullable: false),
                    ImageId = table.Column<string>(type: "text", nullable: true),
                    VolunteeringId = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VolunteeringCarouselPages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VolunteeringCarouselPages_Files_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Files",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VolunteeringCarouselPages_Volunteerings_VolunteeringId",
                        column: x => x.VolunteeringId,
                        principalTable: "Volunteerings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_VolunteeringBenefits_Created",
                table: "VolunteeringBenefits",
                column: "Created");

            migrationBuilder.CreateIndex(
                name: "IX_VolunteeringBenefits_ImageId",
                table: "VolunteeringBenefits",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_VolunteeringBenefits_Updated",
                table: "VolunteeringBenefits",
                column: "Updated");

            migrationBuilder.CreateIndex(
                name: "IX_VolunteeringBenefits_VolunteeringId",
                table: "VolunteeringBenefits",
                column: "VolunteeringId");

            migrationBuilder.CreateIndex(
                name: "IX_VolunteeringCarouselPages_Created",
                table: "VolunteeringCarouselPages",
                column: "Created");

            migrationBuilder.CreateIndex(
                name: "IX_VolunteeringCarouselPages_ImageId",
                table: "VolunteeringCarouselPages",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_VolunteeringCarouselPages_Updated",
                table: "VolunteeringCarouselPages",
                column: "Updated");

            migrationBuilder.CreateIndex(
                name: "IX_VolunteeringCarouselPages_VolunteeringId",
                table: "VolunteeringCarouselPages",
                column: "VolunteeringId");

            migrationBuilder.CreateIndex(
                name: "IX_Volunteerings_Created",
                table: "Volunteerings",
                column: "Created");

            migrationBuilder.CreateIndex(
                name: "IX_Volunteerings_Updated",
                table: "Volunteerings",
                column: "Updated");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VolunteeringBenefits");

            migrationBuilder.DropTable(
                name: "VolunteeringCarouselPages");

            migrationBuilder.DropTable(
                name: "Volunteerings");

            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "Pages");
        }
    }
}
