namespace SistemaEscolar.Domain.Entities
{
    public class Responsavel : Pessoa
    {
        // Relacionamentos
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }

        public int EscolaId { get; set; }
        public Escola Escola { get; set; }
    }
}
