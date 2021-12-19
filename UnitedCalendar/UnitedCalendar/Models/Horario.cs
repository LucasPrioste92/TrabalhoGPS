using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UnitedCalendar.Models
{
    public partial class Horario
    {
        public Horario()
        {
            AtividadeExtra = new HashSet<AtividadeExtra>();
            Gabinete = new HashSet<Gabinete>();
            HorarioDisciplina = new HashSet<HorarioDisciplina>();
        }

        public int Id { get; set; }
        public int IdUser { get; set; }
        public bool Publico { get; set; }

        public virtual User IdUserNavigation { get; set; }
        public virtual ICollection<AtividadeExtra> AtividadeExtra { get; set; }
        public virtual ICollection<Gabinete> Gabinete { get; set; }
        public virtual ICollection<HorarioDisciplina> HorarioDisciplina { get; set; }
    }
}
