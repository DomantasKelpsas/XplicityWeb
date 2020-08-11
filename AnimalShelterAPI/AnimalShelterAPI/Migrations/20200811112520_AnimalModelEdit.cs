using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalShelterAPI.Migrations
{
    public partial class AnimalModelEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Animals",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "SpecialID",
                table: "Animals",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpecialID",
                table: "Animals");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Animals",
                newName: "ID");
        }
    }
}
