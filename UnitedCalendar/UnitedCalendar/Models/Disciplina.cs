using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UnitedCalendar.Models
{
    public class Disciplina
    {
        [Key]
        public int IdDisciplina { get; set; }

        [Required(ErrorMessage = "O Nome da Disciplina é um campo Obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Local da Disciplina é um campo Obrigatório.")]
        public string Local { get; set; }

        [Required(ErrorMessage = "O tipo de turma da Disciplina é um campo Obrigatório.")]
        public string Turma { get; set; } //Se é Teorico, Pratico ou Teorico Pratico

        [Required(ErrorMessage = "O Dia da Semana da Disciplina é um campo Obrigatório.")]
        public string DiaSemana { get; set; } //Segunda, Terça, Quarta, etc.

        [Required(ErrorMessage = "A Hora de Começo é um campo Obrigatório.")]
        [RegularExpression(@"^[0-9]{2}:[0-9]{2}", ErrorMessage = "Caracteres não permitidos! Formato: 12:30")]
        public string HoraComeco { get; set; }

        [Required(ErrorMessage = "A Hora de Termino é um campo Obrigatório.")]
        [RegularExpression(@"^[0-9]{2}:[0-9]{2}", ErrorMessage = "Caracteres não permitidos! Formato: 12:30")]
        public string HoraTermino { get; set; }


        [Required(ErrorMessage = "O Curso é um campo Obrigatório.")]
        public int CursoIdCurso { get; set; }
        public virtual Curso Curso { get; set; } //Fk Curso

        public ICollection<HorarioDisciplina> HorarioDisciplina { get; set; } //Uma Disciplina tem varios horarios, e um horario tem várias disciplinas
    }
}
