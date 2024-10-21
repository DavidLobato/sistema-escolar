using SistemaEscolar.Domain.Entities;

namespace SistemaEscolar.Domain.Interfaces
{
    public interface ITurmaRepository
    {
        Task<Turma> BuscarPorId(int id);
        Task<IEnumerable<Turma>> ListarTodos();
        Task<Turma> Adicionar(Turma turma);
        Task<Turma> Atualizar(Turma turma);
        Task<bool> Excluir(int id);
    }
}
