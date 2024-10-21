using System.ComponentModel.DataAnnotations;

namespace SistemaEscolar.Domain.Entities
{
    public class AgendaDoAluno
    {
        public int Id { get; set; }
        [Required]
        public string Mensagem { get; set; } = string.Empty;

        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }

        public int EscolaId { get; set; }
        public Escola Escola { get; set; }
    }
}
