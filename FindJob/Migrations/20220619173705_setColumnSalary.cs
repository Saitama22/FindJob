using Microsoft.EntityFrameworkCore.Migrations;

namespace FindJob.Migrations
{
#pragma warning disable IDE1006 // Стили именования
	public partial class setColumnSalary : Migration
#pragma warning restore IDE1006 // Стили именования
	{
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Salary",
                table: "Resumes",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Salary",
                table: "Resumes",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);
        }
    }
}
