
using SistemaEscolar.Domain.Entities;

namespace SistemaEscolar.Domain.Interfaces
{
    public interface INotaRepository
    {
        Task<Nota> BuscarPorId(int id);
        Task<IEnumerable<Nota>> ListarTodos();
        Task<Nota> Adicionar(Nota nota);
        Task<Nota> Atualizar(Nota nota);
        Task<bool> Excluir(int id);
    }
}
