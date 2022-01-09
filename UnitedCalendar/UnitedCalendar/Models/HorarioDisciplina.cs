using System.ComponentModel.DataAnnotations;

namespace UnitedCalendar.Models
{
    public class HorarioDisciplina
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int HorarioId { get; set; }
        [Required]
        public int DisciplinaId { get; set; }

        public virtual Horario Horario { get; set; }
        public virtual Disciplina Disciplina { get; set; }
    }
}
