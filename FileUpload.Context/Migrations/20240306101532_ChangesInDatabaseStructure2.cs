using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FileUpload.Context.Migrations
{
    public partial class ChangesInDatabaseStructure2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UploadFile_TextFiles_TextFileId",
                table: "UploadFile");

            migrationBuilder.AddForeignKey(
                name: "FK_UploadFile_TextFiles_TextFileId",
                table: "UploadFile",
                column: "TextFileId",
                principalTable: "TextFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UploadFile_TextFiles_TextFileId",
                table: "UploadFile");

            migrationBuilder.AddForeignKey(
                name: "FK_UploadFile_TextFiles_TextFileId",
                table: "UploadFile",
                column: "TextFileId",
                principalTable: "TextFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
