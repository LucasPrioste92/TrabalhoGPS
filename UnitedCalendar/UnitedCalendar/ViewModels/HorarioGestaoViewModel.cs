using System.Collections.Generic;
using UnitedCalendar.Models;

namespace UnitedCalendar.ViewModels
{
    public class HorarioGestaoViewModel
    {
        public HorarioGestaoViewModel()
        {
            Disciplinas = new List<Disciplina>();
            Gabinetes = new List<Gabinete>();
            AtividadeExtras = new List<AtividadeExtra>();
        }

        public Horario Horario { get; set; }
        public ApplicationUser User { get; set; }
        public List<Disciplina> Disciplinas { get; set; }
        public List<Gabinete> Gabinetes { get; set; }
        public List<AtividadeExtra> AtividadeExtras { get; set; }
    }
}
