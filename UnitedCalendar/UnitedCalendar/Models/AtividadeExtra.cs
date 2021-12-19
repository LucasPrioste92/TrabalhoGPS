using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UnitedCalendar.Models
{
    public partial class AtividadeExtra
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdHorario { get; set; }
        public string Nome { get; set; }
        public TimeSpan HoraCom { get; set; }
        public TimeSpan HoraFim { get; set; }
        public int DiaSemana { get; set; }

        public virtual Horario IdHorarioNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}
