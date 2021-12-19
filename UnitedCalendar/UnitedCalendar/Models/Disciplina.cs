using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UnitedCalendar.Models
{
    public partial class Disciplina
    {
        public Disciplina()
        {
            HorarioDisciplina = new HashSet<HorarioDisciplina>();
        }

        public int Id { get; set; }
        public int IdCurso { get; set; }
        public string Nome { get; set; }
        public TimeSpan HoraTermino { get; set; }
        public TimeSpan HoraComeco { get; set; }
        public string Turma { get; set; }
        public string Local { get; set; }
        public int DiaSemana { get; set; }

        public virtual Curso IdCursoNavigation { get; set; }
        public virtual ICollection<HorarioDisciplina> HorarioDisciplina { get; set; }
    }
}
