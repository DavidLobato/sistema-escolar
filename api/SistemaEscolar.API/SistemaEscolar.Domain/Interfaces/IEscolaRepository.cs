using SistemaEscolar.Domain.Entities;

namespace SistemaEscolar.Domain.Interfaces
{
    public interface IEscolaRepository
    {
        Task<Escola> BuscarPorId(int id);
        Task<IEnumerable<Escola>> ListarTodos();
        Task<Escola> Adicionar(Escola escola);
        Task<Escola> Atualizar(Escola escola);
        Task<bool> Excluir(int id);
    }
}
