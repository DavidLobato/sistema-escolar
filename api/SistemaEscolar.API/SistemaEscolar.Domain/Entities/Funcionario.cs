namespace SistemaEscolar.Domain.Entities
{
    public class Funcionario : Pessoa
    {
        // Relacionamentos
        public int EscolaId { get; set; }
        public Escola Escola { get; set; } // Relação com Escola
        public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    }
}
