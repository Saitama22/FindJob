using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FindJob.Migrations
{
    public partial class Images : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Resumes");

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "Resumes",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Image = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Resumes_ImageId",
                table: "Resumes",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Resumes_Images_ImageId",
                table: "Resumes",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resumes_Images_ImageId",
                table: "Resumes");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Resumes_ImageId",
                table: "Resumes");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Resumes");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Resumes",
                type: "bytea",
                nullable: true);
        }
    }
}
