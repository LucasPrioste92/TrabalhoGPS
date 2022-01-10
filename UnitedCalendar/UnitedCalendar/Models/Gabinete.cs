using System.ComponentModel.DataAnnotations;

namespace UnitedCalendar.Models
{
    public class Gabinete
    {
        [Key]
        public int IdGabinete { get; set; }

        [Required(ErrorMessage = "O Nome do Gabinete é um campo Obrigatório.")]
        public string Nome { get; set; }      

        [Required(ErrorMessage = "A Descricao do Gabinete é um campo Obrigatório.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O Local do Gabinete é um campo Obrigatório.")]
        public string Local { get; set; }

        [Required(ErrorMessage = "O Dia da Semana da Disciplina é um campo Obrigatório.")]
        public string DiaSemana { get; set; } //Segunda, Terça, Quarta, etc.

        [Required(ErrorMessage = "A Hora de Começo é um campo Obrigatório.")]
        [RegularExpression(@"^[0-9]{2}:[0-9]{2}", ErrorMessage = "Caracteres não permitidos! Formato: 12:30")]
        public string HoraComeco { get; set; }

        [Required(ErrorMessage = "A Hora de Termino é um campo Obrigatório.")]
        [RegularExpression(@"^[0-9]{2}:[0-9]{2}", ErrorMessage = "Caracteres não permitidos! Formato: 12:30")]
        public string HoraTermino { get; set; }


        [Required(ErrorMessage = "O Horario é um campo Obrigatório.")]
        public int HorarioIdHorario { get; set; }
        public virtual Horario Horario { get; set; } //Fk Horario

        [Required(ErrorMessage = "O Utilizador é um campo Obrigatório.")]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; } //Fk User
    }
}
