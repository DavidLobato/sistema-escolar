using SistemaEscolar.Domain.Entities;

namespace SistemaEscolar.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<Usuario> BuscarPorId(int id);
        Task<IEnumerable<Usuario>> ListarTodos();
        Task<Usuario> Adicionar(Usuario usuario);
        Task<Usuario> Atualizar(Usuario usuario);
        Task<bool> Excluir(int id);

    }
}
