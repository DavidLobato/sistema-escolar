using System.ComponentModel.DataAnnotations;

namespace SistemaEscolar.Domain.Entities
{
    public class Prova
    {
        public int Id { get; set; }

        [Required]
        public string Descricao { get; set; } = string.Empty;

        public int DisciplinaId { get; set; }
        public Disciplina Disciplina { get; set; }

        // Relacionamentos
        public ICollection<Nota> Notas { get; set; } = new List<Nota>();
    }
}
