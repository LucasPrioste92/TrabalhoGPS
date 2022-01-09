using Microsoft.EntityFrameworkCore.Migrations;

namespace UnitedCalendar.Migrations
{
    public partial class faculdade2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Faculdade",
                table: "Curso");

            migrationBuilder.AddColumn<int>(
                name: "IdFaculdade",
                table: "Curso",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Faculdade",
                columns: table => new
                {
                    IdFaculdade = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculdade", x => x.IdFaculdade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Curso_FaculdadeIdFaculdade",
                table: "Curso",
                column: "IdFaculdade");

            migrationBuilder.AddForeignKey(
                name: "FK_Curso_Faculdade_FaculdadeIdFaculdade",
                table: "Curso",
                column: "IdFaculdade",
                principalTable: "Faculdade",
                principalColumn: "IdFaculdade",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Curso_Faculdade_FaculdadeIdFaculdade",
                table: "Curso");

            migrationBuilder.DropTable(
                name: "Faculdade");

            migrationBuilder.DropIndex(
                name: "IX_Curso_FaculdadeIdFaculdade",
                table: "Curso");

            migrationBuilder.DropColumn(
                name: "FaculdadeIdFaculdade",
                table: "Curso");

            migrationBuilder.DropColumn(
                name: "IdFaculdade",
                table: "Curso");

            migrationBuilder.AddColumn<string>(
                name: "Faculdade",
                table: "Curso",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
