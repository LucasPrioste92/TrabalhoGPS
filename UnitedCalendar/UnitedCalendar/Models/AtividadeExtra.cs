using System.ComponentModel.DataAnnotations;

namespace UnitedCalendar.Models
{
    public class AtividadeExtra
    {
        [Key]
        public int IdAtividadeExtra { get; set; }

        [Required(ErrorMessage = "O Nome da Atividade Extra é um campo Obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Dia da Semana da Atividade Extra é um campo Obrigatório.")]
        public string DiaSemana { get; set; } //Segunda, Terça, Quarta, etc.

        [Required(ErrorMessage = "A Hora de Começo é um campo Obrigatório.")]
        [RegularExpression(@"^[0-9]{2}:[0-9]{2}", ErrorMessage = "Caracteres não permitidos! Formato: 12:30")]
        public string HoraComeco { get; set; }

        [Required(ErrorMessage = "A Hora de Termino é um campo Obrigatório.")]
        [RegularExpression(@"^[0-9]{2}:[0-9]{2}", ErrorMessage = "Caracteres não permitidos! Formato: 12:30")]
        public string HoraTermino { get; set; }


        [Required(ErrorMessage = "O Horario é um campo Obrigatório.")]
        public int IdHorario { get; set; }
        public virtual Horario Horario { get; set; } //Fk Horario

        [Required(ErrorMessage = "O Utilizador é um campo Obrigatório.")]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; } //Fk User
    }
}
