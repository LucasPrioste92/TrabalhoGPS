using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UnitedCalendar.Models
{
    public partial class HorarioDisciplina
    {
        public int IdDisciplina { get; set; }
        public int IdHorario { get; set; }
        public int Id { get; set; }

        public virtual Disciplina IdDisciplinaNavigation { get; set; }
        public virtual Horario IdHorarioNavigation { get; set; }
    }
}
