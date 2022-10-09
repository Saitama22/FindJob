using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FindJob.Migrations
{
    public partial class Profiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Resumes");

            migrationBuilder.AddColumn<Guid>(
                name: "EmployerProfilId",
                table: "Vacancies",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "WorkerProfilId",
                table: "Resumes",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EmployerProfil",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Picture = table.Column<byte[]>(type: "bytea", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployerProfil", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkerProfil",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Region = table.Column<string>(type: "text", nullable: true),
                    DefaultPicture = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkerProfil", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vacancies_EmployerProfilId",
                table: "Vacancies",
                column: "EmployerProfilId");

            migrationBuilder.CreateIndex(
                name: "IX_Resumes_WorkerProfilId",
                table: "Resumes",
                column: "WorkerProfilId");

            migrationBuilder.AddForeignKey(
                name: "FK_Resumes_WorkerProfil_WorkerProfilId",
                table: "Resumes",
                column: "WorkerProfilId",
                principalTable: "WorkerProfil",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancies_EmployerProfil_EmployerProfilId",
                table: "Vacancies",
                column: "EmployerProfilId",
                principalTable: "EmployerProfil",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resumes_WorkerProfil_WorkerProfilId",
                table: "Resumes");

            migrationBuilder.DropForeignKey(
                name: "FK_Vacancies_EmployerProfil_EmployerProfilId",
                table: "Vacancies");

            migrationBuilder.DropTable(
                name: "EmployerProfil");

            migrationBuilder.DropTable(
                name: "WorkerProfil");

            migrationBuilder.DropIndex(
                name: "IX_Vacancies_EmployerProfilId",
                table: "Vacancies");

            migrationBuilder.DropIndex(
                name: "IX_Resumes_WorkerProfilId",
                table: "Resumes");

            migrationBuilder.DropColumn(
                name: "EmployerProfilId",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "WorkerProfilId",
                table: "Resumes");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Vacancies",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Resumes",
                type: "text",
                nullable: true);
        }
    }
}
