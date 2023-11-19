using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmWebApi.DAL.Migrations
{
    public partial class ManyToManyCategory_Film : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Films_Categories_CategoryID",
                table: "Films");

            migrationBuilder.DropIndex(
                name: "IX_Films_CategoryID",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Films");

            migrationBuilder.CreateTable(
                name: "CategoryFilm",
                columns: table => new
                {
                    CategorysId = table.Column<int>(type: "int", nullable: false),
                    FilmsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryFilm", x => new { x.CategorysId, x.FilmsId });
                    table.ForeignKey(
                        name: "FK_CategoryFilm_Categories_CategorysId",
                        column: x => x.CategorysId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryFilm_Films_FilmsId",
                        column: x => x.FilmsId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryFilm_FilmsId",
                table: "CategoryFilm",
                column: "FilmsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryFilm");

            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Films",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Films_CategoryID",
                table: "Films",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Films_Categories_CategoryID",
                table: "Films",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
