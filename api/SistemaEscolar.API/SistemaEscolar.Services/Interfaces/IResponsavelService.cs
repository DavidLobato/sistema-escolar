using SistemaEscolar.Domain.Entities;

namespace SistemaEscolar.Services.Interfaces
{
    public interface IResponsavelService
    {
        Task<Responsavel> BuscarPorId(int id);
        Task<IEnumerable<Responsavel>> ListarTodos();
        Task<Responsavel> Adicionar(Responsavel responsavel);
        Task<Responsavel> Atualizar(Responsavel responsavel);
        Task<bool> Excluir(int id);

    }
}
