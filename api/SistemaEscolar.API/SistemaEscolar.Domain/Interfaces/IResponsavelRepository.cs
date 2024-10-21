using SistemaEscolar.Domain.Entities;

namespace SistemaEscolar.Domain.Interfaces
{
    public interface IResponsavelRepository
    {
        Task<Responsavel> BuscarPorId(int id);
        Task<IEnumerable<Responsavel>> ListarTodos();
        Task<Responsavel> Adicionar(Responsavel responsavel);
        Task<Responsavel> Atualizar(Responsavel responsavel);
        Task<bool> Excluir(int id);

    }
}
