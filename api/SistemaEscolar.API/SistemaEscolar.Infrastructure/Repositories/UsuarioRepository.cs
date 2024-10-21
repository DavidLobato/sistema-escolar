using Microsoft.EntityFrameworkCore;
using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Domain.Interfaces;
using SistemaEscolar.Infrastructure.Data;

namespace SistemaEscolar.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _appDbContext;
        public UsuarioRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Usuario> Adicionar(Usuario usuario)
        {
            await _appDbContext.Usuarios.AddAsync(usuario);
            await _appDbContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> Atualizar(Usuario usuario)
        {
            _appDbContext.Usuarios.Update(usuario);
            await _appDbContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> BuscarPorId(int id)
        {
            var usuario = await _appDbContext.Usuarios.FindAsync(id);
            if (usuario == null)
                throw new KeyNotFoundException("Usuario não encontrado");
            return usuario;
        }

        public async Task<bool> Excluir(int id)
        {
            var usuario = await _appDbContext.Usuarios.FindAsync(id);
            if (usuario == null)
                return false;

            _appDbContext.Usuarios.Remove(usuario);
            await _appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Usuario>> ListarTodos()
        {
            return await _appDbContext.Usuarios.ToListAsync();
        }
    }
}
