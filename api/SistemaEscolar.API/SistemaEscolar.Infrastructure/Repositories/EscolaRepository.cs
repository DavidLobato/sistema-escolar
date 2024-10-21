using Microsoft.EntityFrameworkCore;
using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Domain.Interfaces;
using SistemaEscolar.Infrastructure.Data;

namespace SistemaEscolar.Infrastructure.Repositories
{
    public class EscolaRepository : IEscolaRepository
    {
        private readonly AppDbContext _appDbContext;

        public EscolaRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Escola> Adicionar(Escola escola)
        {
            await _appDbContext.Escolas.AddAsync(escola);
            await _appDbContext.SaveChangesAsync();
            return escola;
        }

        public async Task<Escola> Atualizar(Escola escola)
        {
            _appDbContext.Escolas.Update(escola);
            await _appDbContext.SaveChangesAsync();
            return escola;
        }

        public async Task<Escola> BuscarPorId(int id)
        {
            var escola = await _appDbContext.Escolas.FindAsync(id);
            if (escola == null)
                throw new KeyNotFoundException("Escola não encontrada");
            return escola;
        }

        public async Task<bool> Excluir(int id)
        {
            var escola = await _appDbContext.Escolas.FindAsync(id);
            if (escola == null)
                return false;

            _appDbContext.Escolas.Remove(escola);
            await _appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Escola>> ListarTodos()
        {
            return await _appDbContext.Escolas.ToListAsync();
        }
    }
}
