using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddReviews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PictureDatasetId",
                table: "Pictures",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SurenessPercent",
                table: "Annotations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AnnotationReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpertId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AnnotationId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnotationReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnnotationReviews_Annotations_AnnotationId",
                        column: x => x.AnnotationId,
                        principalTable: "Annotations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnnotationReviews_AspNetUsers_ExpertId",
                        column: x => x.ExpertId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PictureDatasets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PictureDatasets", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_PictureDatasetId",
                table: "Pictures",
                column: "PictureDatasetId");

            migrationBuilder.CreateIndex(
                name: "IX_AnnotationReviews_AnnotationId",
                table: "AnnotationReviews",
                column: "AnnotationId");

            migrationBuilder.CreateIndex(
                name: "IX_AnnotationReviews_ExpertId",
                table: "AnnotationReviews",
                column: "ExpertId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_PictureDatasets_PictureDatasetId",
                table: "Pictures",
                column: "PictureDatasetId",
                principalTable: "PictureDatasets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_PictureDatasets_PictureDatasetId",
                table: "Pictures");

            migrationBuilder.DropTable(
                name: "AnnotationReviews");

            migrationBuilder.DropTable(
                name: "PictureDatasets");

            migrationBuilder.DropIndex(
                name: "IX_Pictures_PictureDatasetId",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "PictureDatasetId",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "SurenessPercent",
                table: "Annotations");
        }
    }
}
