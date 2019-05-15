using Microsoft.EntityFrameworkCore.Migrations;

namespace firstwebapp.Migrations
{
    public partial class UpdatedQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EingereichtVon",
                table: "Questions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EingereichtVon",
                table: "Questions");
        }
    }
}
