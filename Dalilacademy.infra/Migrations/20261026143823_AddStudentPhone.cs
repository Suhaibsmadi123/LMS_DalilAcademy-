using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dalilacademy.infra.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentPhone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "phonenumber",
                table: "Students",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "phonenumber",
                table: "Students");
        }
    }
}
