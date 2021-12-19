using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UnitedCalendar.Models
{
    public partial class User
    {
        public User()
        {
            AtividadeExtra = new HashSet<AtividadeExtra>();
            Gabinete = new HashSet<Gabinete>();
            Horario = new HashSet<Horario>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int TipoConta { get; set; }
        public string Escola { get; set; }
        public int Estado { get; set; }
        public string CodigoRec { get; set; }

        public virtual ICollection<AtividadeExtra> AtividadeExtra { get; set; }
        public virtual ICollection<Gabinete> Gabinete { get; set; }
        public virtual ICollection<Horario> Horario { get; set; }
    }
}
