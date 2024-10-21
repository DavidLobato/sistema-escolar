using SistemaEscolar.Domain.Entities;

namespace SistemaEscolar.Domain.Interfaces
{
    public interface IProfessorRepository
    {
        Task<Professor> BuscarPorId(int id);
        Task<IEnumerable<Professor>> ListarTodos();
        Task<Professor> Adicionar(Professor professor);
        Task<Professor> Atualizar(Professor professor);
        Task<bool> Excluir(int id);
    }
}
