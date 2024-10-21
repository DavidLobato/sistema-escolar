using SistemaEscolar.Domain.Entities;

namespace SistemaEscolar.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> BuscarPorId(int id);
        Task<IEnumerable<Usuario>> ListarTodos();
        Task<Usuario> Adicionar(Usuario usuario);
        Task<Usuario> Atualizar(Usuario usuario);
        Task<bool> Excluir(int id);

    }
}
