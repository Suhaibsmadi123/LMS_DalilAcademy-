using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dalilacademy.infra.Migrations
{
    /// <inheritdoc />
    public partial class ConfigEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Students_email",
                table: "Students",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Students_email",
                table: "Students");
        }
    }
}
