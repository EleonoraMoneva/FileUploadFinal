using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FileUpload.Context.Migrations
{
    public partial class ChangesInDatabaseStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "UploadFile");

            migrationBuilder.AddColumn<Guid>(
                name: "TextFileId",
                table: "UploadFile",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "TextFiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UploadedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextFiles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UploadFile_TextFileId",
                table: "UploadFile",
                column: "TextFileId");

            migrationBuilder.AddForeignKey(
                name: "FK_UploadFile_TextFiles_TextFileId",
                table: "UploadFile",
                column: "TextFileId",
                principalTable: "TextFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UploadFile_TextFiles_TextFileId",
                table: "UploadFile");

            migrationBuilder.DropTable(
                name: "TextFiles");

            migrationBuilder.DropIndex(
                name: "IX_UploadFile_TextFileId",
                table: "UploadFile");

            migrationBuilder.DropColumn(
                name: "TextFileId",
                table: "UploadFile");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "UploadFile",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
