using System.ComponentModel.DataAnnotations;

namespace UnitedCalendar.Models
{
    public class Curso
    {
        [Key]
        public int IdCurso { get; set; }

        [Required(ErrorMessage = "O Nome do Curso é um campo Obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A faculdade é um campo Obrigatório.")]
        public int FaculdadeIdFaculdade { get; set; }
        public virtual Faculdade Faculdade { get; set; } //Fk Curso
    }
}
