using Microsoft.EntityFrameworkCore;
using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Domain.Interfaces;
using SistemaEscolar.Infrastructure.Data;

namespace SistemaEscolar.Infrastructure.Repositories
{
    public class ProvaRepository : IProvaRepository
    {
        private readonly AppDbContext _appDbContext;
        public ProvaRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Prova> Adicionar(Prova prova)
        {
            await _appDbContext.Provas.AddAsync(prova);
            await _appDbContext.SaveChangesAsync();
            return prova;
        }

        public async Task<Prova> Atualizar(Prova prova)
        {
            _appDbContext.Provas.Update(prova);
            await _appDbContext.SaveChangesAsync();
            return prova;
        }

        public async Task<Prova> BuscarPorId(int id)
        {
            var prova = await _appDbContext.Provas.FindAsync(id);
            if (prova == null)
                throw new KeyNotFoundException("Prova não encontrada");
            return prova;
        }

        public async Task<bool> Excluir(int id)
        {
            var prova = await _appDbContext.Provas.FindAsync(id);
            if (prova == null)
                return false;

            _appDbContext.Provas.Remove(prova);
            await _appDbContext.SaveChangesAsync();
            return true;

        }

        public async Task<IEnumerable<Prova>> ListarTodos()
        {
            return await _appDbContext.Provas.ToListAsync();
        }
    }
}
