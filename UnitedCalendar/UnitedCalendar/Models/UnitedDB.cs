using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UnitedCalendar.Models
{
    public partial class UnitedDB : DbContext
    {
        public UnitedDB()
        {
        }

        public UnitedDB(DbContextOptions<UnitedDB> options)
            : base(options)
        {
        }

        public virtual DbSet<AtividadeExtra> AtividadeExtra { get; set; }
        public virtual DbSet<Curso> Curso { get; set; }
        public virtual DbSet<Disciplina> Disciplina { get; set; }
        public virtual DbSet<Gabinete> Gabinete { get; set; }
        public virtual DbSet<Horario> Horario { get; set; }
        public virtual DbSet<HorarioDisciplina> HorarioDisciplina { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=UnitedCalendar;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AtividadeExtra>(entity =>
            {
                entity.Property(e => e.DiaSemana).HasColumnName("diaSemana");

                entity.Property(e => e.HoraCom).HasColumnName("horaCom");

                entity.Property(e => e.HoraFim).HasColumnName("horaFim");

                entity.Property(e => e.IdHorario).HasColumnName("idHorario");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(45);

                entity.HasOne(d => d.IdHorarioNavigation)
                    .WithMany(p => p.AtividadeExtra)
                    .HasForeignKey(d => d.IdHorario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AtividadeExtra_ToHorario");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.AtividadeExtra)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AtividadeExtra_ToUser");
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Disciplina>(entity =>
            {
                entity.Property(e => e.DiaSemana).HasColumnName("diaSemana");

                entity.Property(e => e.HoraComeco).HasColumnName("horaComeco");

                entity.Property(e => e.HoraTermino).HasColumnName("horaTermino");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.Property(e => e.Local)
                    .IsRequired()
                    .HasColumnName("local")
                    .HasMaxLength(45);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(95);

                entity.Property(e => e.Turma)
                    .IsRequired()
                    .HasColumnName("turma")
                    .HasMaxLength(20);

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Disciplina)
                    .HasForeignKey(d => d.IdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Disciplina_ToCurso");
            });

            modelBuilder.Entity<Gabinete>(entity =>
            {
                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao")
                    .HasMaxLength(85);

                entity.Property(e => e.DiaSemana).HasColumnName("diaSemana");

                entity.Property(e => e.HoraComeco).HasColumnName("horaComeco");

                entity.Property(e => e.HoraTermino).HasColumnName("horaTermino");

                entity.Property(e => e.IdHorario).HasColumnName("idHorario");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.Local)
                    .IsRequired()
                    .HasColumnName("local")
                    .HasMaxLength(45);

                entity.HasOne(d => d.IdHorarioNavigation)
                    .WithMany(p => p.Gabinete)
                    .HasForeignKey(d => d.IdHorario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Gabinete_Horario");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Gabinete)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Gabinete_User");
            });

            modelBuilder.Entity<Horario>(entity =>
            {
                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.Publico).HasColumnName("publico");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Horario)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Horario_ToUser");
            });

            modelBuilder.Entity<HorarioDisciplina>(entity =>
            {
                entity.Property(e => e.IdDisciplina).HasColumnName("idDisciplina");

                entity.Property(e => e.IdHorario).HasColumnName("idHorario");

                entity.HasOne(d => d.IdDisciplinaNavigation)
                    .WithMany(p => p.HorarioDisciplina)
                    .HasForeignKey(d => d.IdDisciplina)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HorarioDisciplina_Disciplina");

                entity.HasOne(d => d.IdHorarioNavigation)
                    .WithMany(p => p.HorarioDisciplina)
                    .HasForeignKey(d => d.IdHorario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HorarioDisciplina_Horario");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.CodigoRec).HasColumnName("codigoRec");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(60);

                entity.Property(e => e.Escola)
                    .IsRequired()
                    .HasColumnName("escola")
                    .HasMaxLength(50);

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(45);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password");

                entity.Property(e => e.TipoConta).HasColumnName("tipoConta");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
