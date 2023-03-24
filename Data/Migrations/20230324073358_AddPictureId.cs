using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnnotateAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddPictureId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Annotations_AspNetUsers_AuthorId",
                table: "Annotations");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "Annotations",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PictureId",
                table: "Annotations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Annotations_PictureId",
                table: "Annotations",
                column: "PictureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Annotations_AspNetUsers_AuthorId",
                table: "Annotations",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Annotations_Pictures_PictureId",
                table: "Annotations",
                column: "PictureId",
                principalTable: "Pictures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Annotations_AspNetUsers_AuthorId",
                table: "Annotations");

            migrationBuilder.DropForeignKey(
                name: "FK_Annotations_Pictures_PictureId",
                table: "Annotations");

            migrationBuilder.DropIndex(
                name: "IX_Annotations_PictureId",
                table: "Annotations");

            migrationBuilder.DropColumn(
                name: "PictureId",
                table: "Annotations");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "Annotations",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Annotations_AspNetUsers_AuthorId",
                table: "Annotations",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
