using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UnitedCalendar.Migrations
{
    public partial class tabelasNovas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    IdCurso = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.IdCurso);
                });

            migrationBuilder.CreateTable(
                name: "Horario",
                columns: table => new
                {
                    IdHorario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Publico = table.Column<bool>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horario", x => x.IdHorario);
                    table.ForeignKey(
                        name: "FK_Horario_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Disciplina",
                columns: table => new
                {
                    IdDisciplina = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: false),
                    Local = table.Column<string>(nullable: false),
                    Turma = table.Column<string>(nullable: false),
                    DiaSemana = table.Column<string>(nullable: false),
                    HoraComeco = table.Column<string>(nullable: false),
                    HoraTermino = table.Column<string>(nullable: false),
                    IdCurso = table.Column<int>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplina", x => x.IdDisciplina);
                    table.ForeignKey(
                        name: "FK_Disciplina_Curso_CursoIdCurso",
                        column: x => x.IdCurso,
                        principalTable: "Curso",
                        principalColumn: "IdCurso",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AtividadeExtra",
                columns: table => new
                {
                    IdAtividadeExtra = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: false),
                    DiaSemana = table.Column<string>(nullable: false),
                    HoraComeco = table.Column<string>(nullable: false),
                    HoraTermino = table.Column<string>(nullable: false),
                    IdHorario = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtividadeExtra", x => x.IdAtividadeExtra);
                    table.ForeignKey(
                        name: "FK_AtividadeExtra_Horario_HorarioIdHorario",
                        column: x => x.IdHorario,
                        principalTable: "Horario",
                        principalColumn: "IdHorario",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AtividadeExtra_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Gabinete",
                columns: table => new
                {
                    IdGabinete = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: false),
                    Descricao = table.Column<string>(nullable: false),
                    Local = table.Column<string>(nullable: false),
                    DiaSemana = table.Column<string>(nullable: false),
                    HoraComeco = table.Column<string>(nullable: false),
                    HoraTermino = table.Column<string>(nullable: false),
                    IdHorario = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gabinete", x => x.IdGabinete);
                    table.ForeignKey(
                        name: "FK_Gabinete_Horario_HorarioIdHorario",
                        column: x => x.IdHorario,
                        principalTable: "Horario",
                        principalColumn: "IdHorario",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Gabinete_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HorarioDisciplina",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HorarioId = table.Column<int>(nullable: false),
                    DisciplinaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorarioDisciplina", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HorarioDisciplina_Disciplina_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplina",
                        principalColumn: "IdDisciplina",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HorarioDisciplina_Horario_HorarioId",
                        column: x => x.HorarioId,
                        principalTable: "Horario",
                        principalColumn: "IdHorario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AtividadeExtra_HorarioIdHorario",
                table: "AtividadeExtra",
                column: "IdHorario");

            migrationBuilder.CreateIndex(
                name: "IX_AtividadeExtra_UserId",
                table: "AtividadeExtra",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplina_CursoIdCurso",
                table: "Disciplina",
                column: "IdCurso");

            migrationBuilder.CreateIndex(
                name: "IX_Gabinete_HorarioIdHorario",
                table: "Gabinete",
                column: "IdHorario");

            migrationBuilder.CreateIndex(
                name: "IX_Gabinete_UserId",
                table: "Gabinete",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Horario_UserId",
                table: "Horario",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HorarioDisciplina_DisciplinaId",
                table: "HorarioDisciplina",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_HorarioDisciplina_HorarioId",
                table: "HorarioDisciplina",
                column: "HorarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtividadeExtra");

            migrationBuilder.DropTable(
                name: "Gabinete");

            migrationBuilder.DropTable(
                name: "HorarioDisciplina");

            migrationBuilder.DropTable(
                name: "Disciplina");

            migrationBuilder.DropTable(
                name: "Horario");

            migrationBuilder.DropTable(
                name: "Curso");
        }
    }
}
