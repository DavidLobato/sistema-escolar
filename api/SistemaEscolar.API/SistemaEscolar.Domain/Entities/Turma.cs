using System.ComponentModel.DataAnnotations;

namespace SistemaEscolar.Domain.Entities
{
    public class Turma
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; } = string.Empty;

        public int EscolaId { get; set; }
        public Escola Escola { get; set; }

        // Relacionamentos
        public ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();
        public ICollection<Disciplina> Disciplinas { get; set; } = new List<Disciplina>();
    }
}
