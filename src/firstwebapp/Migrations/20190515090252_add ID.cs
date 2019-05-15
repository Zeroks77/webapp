using Microsoft.EntityFrameworkCore.Migrations;

namespace firstwebapp.Migrations
{
    public partial class addID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EingereichtVon",
                table: "Questions",
                newName: "EingereichtVonID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EingereichtVonID",
                table: "Questions",
                newName: "EingereichtVon");
        }
    }
}
