
namespace SistemaEscolar.Domain.Entities
{
    public class Nota
    {
        public int Id { get; set; }

        public double Valor { get; set; }

        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }

        public int ProvaId { get; set; }
        public Prova Prova { get; set; }
    }
}
