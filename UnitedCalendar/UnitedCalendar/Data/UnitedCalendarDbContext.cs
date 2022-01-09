using Microsoft.EntityFrameworkCore;
using UnitedCalendar.Models;

namespace UnitedCalendar.Data
{
    public class UnitedCalendarDbContext : DbContext
    {
        public UnitedCalendarDbContext(DbContextOptions<UnitedCalendarDbContext> options) : base(options)
        {
        }


        public DbSet<Curso> Curso { get; set; }
        public DbSet<Disciplina> Disciplina { get; set; }
        public DbSet<Horario> Horario { get; set; }
        public DbSet<HorarioDisciplina> HorarioDisciplina { get; set; }
        public DbSet<Gabinete> Gabinete { get; set; }
        public DbSet<AtividadeExtra> AtividadeExtra { get; set; }
        public DbSet<Faculdade> Faculdade { get; set; }
    }
}
