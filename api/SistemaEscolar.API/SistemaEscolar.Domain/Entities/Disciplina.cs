using System.ComponentModel.DataAnnotations;

namespace SistemaEscolar.Domain.Entities
{
    public class Disciplina
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; } = string.Empty;

        public int EscolaId { get; set; }
        public Escola Escola { get; set; }

        // Relacionamentos
        public ICollection<Prova> Provas { get; set; } = new List<Prova>();
        public ICollection<Professor> Professores { get; set; } = new List<Professor>();
        public ICollection<Turma> Turmas { get; set; } = new List<Turma>();
    }
}
