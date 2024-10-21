using SistemaEscolar.Domain.Entities;

namespace SistemaEscolar.Services.Interfaces
{
    public interface ITurmaService
    {
        Task<Turma> BuscarPorId(int id);
        Task<IEnumerable<Turma>> ListarTodos();
        Task<Turma> Adicionar(Turma turma);
        Task<Turma> Atualizar(Turma turma);
        Task<bool> Excluir(int id);
    }
}
