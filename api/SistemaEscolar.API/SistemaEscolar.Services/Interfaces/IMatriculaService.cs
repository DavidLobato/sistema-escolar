using SistemaEscolar.Domain.Entities;

namespace SistemaEscolar.Services.Interfaces
{
    public interface IMatriculaService
    {
        Task<Matricula> BuscarPorId(int id);
        Task<IEnumerable<Matricula>> ListarTodos();
        Task<Matricula> Adicionar(Matricula matricula);
        Task<Matricula> Atualizar(Matricula matricula);
        Task<bool> Excluir(int id);
    }
}
