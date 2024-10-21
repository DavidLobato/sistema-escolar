using SistemaEscolar.Domain.Entities;

namespace SistemaEscolar.Domain.Interfaces
{
    public interface IPessoaRepository
    {
        Task<Pessoa> BuscarPorId(int id);
        Task<IEnumerable<Pessoa>> ListarTodos();
        Task<Pessoa> Adicionar(Pessoa pessoa);
        Task<Pessoa> Atualizar(Pessoa pessoa);
        Task<bool> Excluir(int id);

    }
}
