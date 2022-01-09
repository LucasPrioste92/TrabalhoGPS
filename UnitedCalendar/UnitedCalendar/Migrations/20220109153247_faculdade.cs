using Microsoft.EntityFrameworkCore.Migrations;

namespace UnitedCalendar.Migrations
{
    public partial class faculdade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AddColumn<string>(
                name: "Faculdade",
                table: "Curso",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "Faculdade",
                table: "Curso");

            
        }
    }
}
