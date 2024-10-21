using Microsoft.EntityFrameworkCore;
using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Domain.Interfaces;
using SistemaEscolar.Infrastructure.Data;

namespace SistemaEscolar.Infrastructure.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly AppDbContext _appDbContext;

        public PessoaRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Pessoa> Adicionar(Pessoa pessoa)
        {
            await _appDbContext.Pessoas.AddAsync(pessoa);
            await _appDbContext.SaveChangesAsync();
            return pessoa;
        }

        public async Task<Pessoa> Atualizar(Pessoa pessoa)
        {
            _appDbContext.Pessoas.Update(pessoa);
            await _appDbContext.SaveChangesAsync();
            return pessoa;
        }

        public async Task<Pessoa> BuscarPorId(int id)
        {
            var pessoa = await _appDbContext.Pessoas.FindAsync(id);
            if (pessoa == null)
                throw new KeyNotFoundException("Pessoa não encontrada");

            return pessoa;
        }

        public async Task<bool> Excluir(int id)
        {
            var pessoa = await _appDbContext.Pessoas.FindAsync(id);
            if (pessoa == null)
                return false;

            _appDbContext.Pessoas.Remove(pessoa);
            await _appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Pessoa>> ListarTodos()
        {
            return await _appDbContext.Pessoas.ToListAsync();
        }
    }
}
