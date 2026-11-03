using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dalilacademy.infra.Migrations
{
    /// <inheritdoc />
    public partial class AddLevelToCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "level",
                table: "Coures",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "level",
                table: "Coures");
        }
    }
}
