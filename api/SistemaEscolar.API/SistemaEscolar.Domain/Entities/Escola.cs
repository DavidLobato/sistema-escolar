using System.ComponentModel.DataAnnotations;

namespace SistemaEscolar.Domain.Entities
{
    public class Escola
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Nome { get; set; } = string.Empty;
        [Required, MaxLength(100)]
        public string Endereco { get; set; } = string.Empty;
        [Required]
        public string Telefone { get; set; } = string.Empty;
        [Required]
        public string CNPJ { get; set; } = string.Empty;
        [Required]
        public DateTime Tipo { get; set; }

        public ICollection<Aluno> Alunos { get; set; } = new List<Aluno>();
        public ICollection<Professor> Professores { get; set; } = new List<Professor>();
        public ICollection<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();
        public ICollection<Responsavel> Responsaveis { get; set; } = new List<Responsavel>();
        public ICollection<Turma> Turmas { get; set; } = new List<Turma>();
        public ICollection<Prova> Provas { get; set; } = new List<Prova>();
        public ICollection<Nota> Notas { get; set; } = new List<Nota>();
        public ICollection<AgendaDoAluno> AgendasAlunos { get; set; } = new List<AgendaDoAluno>();
        public ICollection<Notificacao> Notificacoes { get; set; } = new List<Notificacao>();
        public ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();

    }
}
