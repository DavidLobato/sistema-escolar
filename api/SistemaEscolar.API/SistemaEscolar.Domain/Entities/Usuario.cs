using System.ComponentModel.DataAnnotations;

namespace SistemaEscolar.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }

        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }

        public int FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }

        public int EscolaId { get; set; }
        public Escola Escola { get; set; }
    }
}
