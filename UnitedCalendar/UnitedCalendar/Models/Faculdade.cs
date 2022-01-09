using System.ComponentModel.DataAnnotations;

namespace UnitedCalendar.Models
{
    public class Faculdade
    {
        [Key]
        public int IdFaculdade { get; set; }

        [Required(ErrorMessage = "O Nome da Faculdade é um campo Obrigatório.")]
        public string Nome { get; set; }
    }
}
