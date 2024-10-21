using SistemaEscolar.Domain.Entities;

namespace SistemaEscolar.Services.Interfaces
{
    public interface IFuncionarioService
    {
        Task<Funcionario> BuscarPorId(int id);
        Task<IEnumerable<Funcionario>> ListarTodos();
        Task<Funcionario> Adicionar(Funcionario funcionario);
        Task<Funcionario> Atualizar(Funcionario funcionario);
        Task<bool> Excluir(int id);
    }
}
