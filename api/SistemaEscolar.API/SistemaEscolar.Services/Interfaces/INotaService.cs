
using SistemaEscolar.Domain.Entities;

namespace SistemaEscolar.Services.Interfaces
{
    public interface INotaService
    {
        Task<Nota> BuscarPorId(int id);
        Task<IEnumerable<Nota>> ListarTodos();
        Task<Nota> Adicionar(Nota nota);
        Task<Nota> Atualizar(Nota nota);
        Task<bool> Excluir(int id);
    }
}
