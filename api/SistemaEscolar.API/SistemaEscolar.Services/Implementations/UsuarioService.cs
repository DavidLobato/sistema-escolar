using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Domain.Interfaces;
using SistemaEscolar.Services.Interfaces;

namespace SistemaEscolar.Services.Implementations
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Usuario> Adicionar(Usuario usuario)
        {
            return await _usuarioRepository.Adicionar(usuario);
        }

        public async Task<Usuario> Atualizar(Usuario usuario)
        {
            return await _usuarioRepository.Atualizar(usuario);
        }

        public async Task<Usuario> BuscarPorId(int id)
        {
            return await _usuarioRepository.BuscarPorId(id);
        }

        public async Task<bool> Excluir(int id)
        {
            return await _usuarioRepository.Excluir(id);
        }

        public async Task<IEnumerable<Usuario>> ListarTodos()
        {
            return await _usuarioRepository.ListarTodos();
        }
    }
}
