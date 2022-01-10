using Microsoft.EntityFrameworkCore.Migrations;

namespace UnitedCalendar.Data.Migrations
{
    public partial class curso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CursoIdCurso",
                table: "AspNetUsers",
                nullable: true);

            

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CursoIdCurso",
                table: "AspNetUsers",
                column: "CursoIdCurso");


            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Curso_CursoIdCurso",
                table: "AspNetUsers",
                column: "CursoIdCurso",
                principalTable: "Curso",
                principalColumn: "IdCurso",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Curso_CursoIdCurso",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Curso");

            migrationBuilder.DropTable(
                name: "Faculdade");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CursoIdCurso",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CursoIdCurso",
                table: "AspNetUsers");
        }
    }
}
