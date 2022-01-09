using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UnitedCalendar.Models
{
    public class Horario
    {
        [Key]
        public int IdHorario { get; set; }

        [Required(ErrorMessage = "A Visibilidade do Horário é um campo Obrigatório.")]
        public bool Publico { get; set; }

        [Required(ErrorMessage = "O Utilizador é um campo Obrigatório.")]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; } //Fk Utilizador

        public ICollection<HorarioDisciplina> HorarioDisciplina { get; set; } //Um horario tem varias disciplinas, e uma disciplina tem vários horarios
    }
}
