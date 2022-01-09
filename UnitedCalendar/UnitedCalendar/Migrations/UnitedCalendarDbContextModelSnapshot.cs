﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UnitedCalendar.Data;

namespace UnitedCalendar.Migrations
{
    [DbContext(typeof(UnitedCalendarDbContext))]
    partial class UnitedCalendarDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UnitedCalendar.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Escola")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ApplicationUser");
                });

            modelBuilder.Entity("UnitedCalendar.Models.AtividadeExtra", b =>
                {
                    b.Property<int>("IdAtividadeExtra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DiaSemana")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoraComeco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoraTermino")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("HorarioIdHorario")
                        .HasColumnType("int");

                    b.Property<int>("IdHorario")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IdAtividadeExtra");

                    b.HasIndex("HorarioIdHorario");

                    b.HasIndex("UserId");

                    b.ToTable("AtividadeExtra");
                });

            modelBuilder.Entity("UnitedCalendar.Models.Curso", b =>
                {
                    b.Property<int>("IdCurso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FaculdadeIdFaculdade")
                        .HasColumnType("int");

                    b.Property<int>("IdFaculdade")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCurso");

                    b.HasIndex("FaculdadeIdFaculdade");

                    b.ToTable("Curso");
                });

            modelBuilder.Entity("UnitedCalendar.Models.Disciplina", b =>
                {
                    b.Property<int>("IdDisciplina")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CursoIdCurso")
                        .HasColumnType("int");

                    b.Property<string>("DiaSemana")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoraComeco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoraTermino")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdCurso")
                        .HasColumnType("int");

                    b.Property<string>("Local")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Turma")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdDisciplina");

                    b.HasIndex("CursoIdCurso");

                    b.ToTable("Disciplina");
                });

            modelBuilder.Entity("UnitedCalendar.Models.Faculdade", b =>
                {
                    b.Property<int>("IdFaculdade")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdFaculdade");

                    b.ToTable("Faculdade");
                });

            modelBuilder.Entity("UnitedCalendar.Models.Gabinete", b =>
                {
                    b.Property<int>("IdGabinete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiaSemana")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoraComeco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoraTermino")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("HorarioIdHorario")
                        .HasColumnType("int");

                    b.Property<int>("IdHorario")
                        .HasColumnType("int");

                    b.Property<string>("Local")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IdGabinete");

                    b.HasIndex("HorarioIdHorario");

                    b.HasIndex("UserId");

                    b.ToTable("Gabinete");
                });

            modelBuilder.Entity("UnitedCalendar.Models.Horario", b =>
                {
                    b.Property<int>("IdHorario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Publico")
                        .HasColumnType("bit");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IdHorario");

                    b.HasIndex("UserId");

                    b.ToTable("Horario");
                });

            modelBuilder.Entity("UnitedCalendar.Models.HorarioDisciplina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DisciplinaId")
                        .HasColumnType("int");

                    b.Property<int>("HorarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DisciplinaId");

                    b.HasIndex("HorarioId");

                    b.ToTable("HorarioDisciplina");
                });

            modelBuilder.Entity("UnitedCalendar.Models.AtividadeExtra", b =>
                {
                    b.HasOne("UnitedCalendar.Models.Horario", "Horario")
                        .WithMany()
                        .HasForeignKey("HorarioIdHorario");

                    b.HasOne("UnitedCalendar.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UnitedCalendar.Models.Curso", b =>
                {
                    b.HasOne("UnitedCalendar.Models.Faculdade", "Faculdade")
                        .WithMany()
                        .HasForeignKey("FaculdadeIdFaculdade");
                });

            modelBuilder.Entity("UnitedCalendar.Models.Disciplina", b =>
                {
                    b.HasOne("UnitedCalendar.Models.Curso", "Curso")
                        .WithMany()
                        .HasForeignKey("CursoIdCurso");
                });

            modelBuilder.Entity("UnitedCalendar.Models.Gabinete", b =>
                {
                    b.HasOne("UnitedCalendar.Models.Horario", "Horario")
                        .WithMany()
                        .HasForeignKey("HorarioIdHorario");

                    b.HasOne("UnitedCalendar.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UnitedCalendar.Models.Horario", b =>
                {
                    b.HasOne("UnitedCalendar.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UnitedCalendar.Models.HorarioDisciplina", b =>
                {
                    b.HasOne("UnitedCalendar.Models.Disciplina", "Disciplina")
                        .WithMany("HorarioDisciplina")
                        .HasForeignKey("DisciplinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UnitedCalendar.Models.Horario", "Horario")
                        .WithMany("HorarioDisciplina")
                        .HasForeignKey("HorarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
