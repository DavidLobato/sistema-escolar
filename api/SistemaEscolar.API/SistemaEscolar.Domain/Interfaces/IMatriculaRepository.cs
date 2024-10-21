using SistemaEscolar.Domain.Entities;

namespace SistemaEscolar.Domain.Interfaces
{
    public interface IMatriculaRepository
    {
        Task<Matricula> BuscarPorId(int id);
        Task<IEnumerable<Matricula>> ListarTodos();
        Task<Matricula> Adicionar(Matricula matricula);
        Task<Matricula> Atualizar(Matricula matricula);
        Task<bool> Excluir(int id);
    }
}
