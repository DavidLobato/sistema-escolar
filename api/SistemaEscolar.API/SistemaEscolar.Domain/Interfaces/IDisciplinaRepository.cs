using SistemaEscolar.Domain.Entities;

namespace SistemaEscolar.Domain.Interfaces
{
    public interface IDisciplinaRepository
    {
        Task<Disciplina> BuscarPorId(int id);
        Task<IEnumerable<Disciplina>> ListarTodos();
        Task<Disciplina> Adicionar(Disciplina disciplina);
        Task<Disciplina> Atualizar(Disciplina disciplina);
        Task<bool> Excluir(int id);
    }
}
