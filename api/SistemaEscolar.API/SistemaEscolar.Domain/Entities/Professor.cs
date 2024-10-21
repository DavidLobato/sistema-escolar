
namespace SistemaEscolar.Domain.Entities
{
    public class Professor : Pessoa
    {
        public int EscolaId { get; set; }
        public Escola Escola { get; set; }
        public ICollection<Disciplina> Disciplinas { get; set; } = new List<Disciplina>();
        public ICollection<Turma> Turmas { get; set; } = new List<Turma>();
        public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();

    }
}
