using SistemaEscolar.Domain.Entities;

namespace SistemaEscolar.Services.Interfaces
{
    public interface IProvaService
    {
        Task<Prova> BuscarPorId(int id);
        Task<IEnumerable<Prova>> ListarTodos();
        Task<Prova> Adicionar(Prova prova);
        Task<Prova> Atualizar(Prova prova);
        Task<bool> Excluir(int id);
    }
}
