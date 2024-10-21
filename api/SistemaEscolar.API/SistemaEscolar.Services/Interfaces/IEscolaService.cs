using SistemaEscolar.Domain.Entities;

namespace SistemaEscolar.Services.Interfaces
{
    public interface IEscolaService
    {
        Task<Escola> BuscarPorId(int id);
        Task<IEnumerable<Escola>> ListarTodos();
        Task<Escola> Adicionar(Escola escola);
        Task<Escola> Atualizar(Escola escola);
        Task<bool> Excluir(int id);
    }
}
