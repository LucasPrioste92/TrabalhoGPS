using System.ComponentModel.DataAnnotations;

namespace UnitedCalendar.Models
{
    public class Curso
    {
        [Key]
        public int IdCurso { get; set; }

        [Required(ErrorMessage = "O Nome do Curso é um campo Obrigatório.")]
        public string Nome { get; set; }
    }
}
