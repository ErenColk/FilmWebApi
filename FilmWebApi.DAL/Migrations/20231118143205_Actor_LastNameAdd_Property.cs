using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmWebApi.DAL.Migrations
{
    public partial class Actor_LastNameAdd_Property : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Films",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Actors",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Films",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Actors",
                newName: "FirstName");
        }
    }
}
