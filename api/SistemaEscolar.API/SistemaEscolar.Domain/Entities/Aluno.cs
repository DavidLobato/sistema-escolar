
namespace SistemaEscolar.Domain.Entities
{
    public class Aluno : Pessoa
    {
        public int EscolaId { get; set; }
        public Escola Escola { get; set; } // Relação com Escola
        public ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();
        public ICollection<Notificacao> Notificacoes { get; set; } = new List<Notificacao>();
        public ICollection<Disciplina> Agendas { get; set; } = new List<Disciplina>();
        public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    }
}
