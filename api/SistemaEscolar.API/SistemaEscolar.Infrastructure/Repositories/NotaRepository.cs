using Microsoft.EntityFrameworkCore;
using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Domain.Interfaces;
using SistemaEscolar.Infrastructure.Data;

namespace SistemaEscolar.Infrastructure.Repositories
{
    public class NotaRepository : INotaRepository
    {
        private readonly AppDbContext _appDbContext;

        public NotaRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Nota> Adicionar(Nota nota)
        {
            await _appDbContext.Notas.AddAsync(nota);
            await _appDbContext.SaveChangesAsync();
            return nota;
        }

        public async Task<Nota> Atualizar(Nota nota)
        {
            _appDbContext.Notas.Update(nota);
            await _appDbContext.SaveChangesAsync();
            return nota;
        }

        public async Task<Nota> BuscarPorId(int id)
        {
            var nota = await _appDbContext.Notas.FindAsync(id);
            if (nota == null)
                throw new KeyNotFoundException("Nota não encontrada");
            return nota;

        }

        public async Task<bool> Excluir(int id)
        {
            var nota = await _appDbContext.Notas.FindAsync(id);
            if (nota == null)
                return false;

            _appDbContext.Notas.Remove(nota);
            await _appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Nota>> ListarTodos()
        {
            return await _appDbContext.Notas.ToListAsync();
        }
    }
}
