using SistemaEscolar.Domain.Entities;

namespace SistemaEscolar.Domain.Interfaces
{
    public interface IProvaRepository
    {
        Task<Prova> BuscarPorId(int id);
        Task<IEnumerable<Prova>> ListarTodos();
        Task<Prova> Adicionar(Prova prova);
        Task<Prova> Atualizar(Prova prova);
        Task<bool> Excluir(int id);
    }
}
