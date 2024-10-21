using SistemaEscolar.Domain.Entities;

namespace SistemaEscolar.Services.Interfaces
{
    public interface IAlunoService
    {
        Task<Aluno> BuscarPorId(int id);
        Task<IEnumerable<Aluno>> ListarTodos();
        Task<Aluno> Adicionar(Aluno aluno);
        Task<Aluno> Atualizar(Aluno aluno);
        Task<bool> Excluir(int id);
    }
}
