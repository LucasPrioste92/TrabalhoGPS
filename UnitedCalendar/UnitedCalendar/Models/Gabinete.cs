using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UnitedCalendar.Models
{
    public partial class Gabinete
    {
        public int Id { get; set; }
        public int IdHorario { get; set; }
        public int IdUser { get; set; }
        public TimeSpan HoraTermino { get; set; }
        public TimeSpan HoraComeco { get; set; }
        public string Local { get; set; }
        public int DiaSemana { get; set; }
        public string Descricao { get; set; }

        public virtual Horario IdHorarioNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}
