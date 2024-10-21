using Microsoft.EntityFrameworkCore;
using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Domain.Interfaces;
using SistemaEscolar.Infrastructure.Data;

namespace SistemaEscolar.Infrastructure.Repositories
{
    public class ResponsavelRepository : IResponsavelRepository
    {
        private readonly AppDbContext _appDbContext;
        public ResponsavelRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Responsavel> Adicionar(Responsavel responsavel)
        {
            await _appDbContext.Responsaveis.AddAsync(responsavel);
            await _appDbContext.SaveChangesAsync();
            return responsavel;
        }

        public async Task<Responsavel> Atualizar(Responsavel responsavel)
        {
            _appDbContext.Responsaveis.Update(responsavel);
            await _appDbContext.SaveChangesAsync();
            return responsavel;
        }

        public async Task<Responsavel> BuscarPorId(int id)
        {
            var responsavel = await _appDbContext.Responsaveis.FindAsync(id);
            if (responsavel == null)
                throw new KeyNotFoundException("Responsavel não encontrado");
            return responsavel;
        }

        public async Task<bool> Excluir(int id)
        {
            var responsavel = await _appDbContext.Responsaveis.FindAsync(id);
            if (responsavel == null)
                return false;


            _appDbContext.Responsaveis.Remove(responsavel);
            await _appDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Responsavel>> ListarTodos()
        {
            return await _appDbContext.Responsaveis.ToListAsync();
        }
    }
}
