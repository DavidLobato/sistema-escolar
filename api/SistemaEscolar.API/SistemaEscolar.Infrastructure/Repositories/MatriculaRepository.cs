using Microsoft.EntityFrameworkCore;
using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Domain.Interfaces;
using SistemaEscolar.Infrastructure.Data;

namespace SistemaEscolar.Infrastructure.Repositories
{
    public class MatriculaRepository : IMatriculaRepository
    {
        private readonly AppDbContext _appDbContext;

        public MatriculaRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Matricula> Adicionar(Matricula matricula)
        {
            await _appDbContext.Matriculas.AddAsync(matricula);
            await _appDbContext.SaveChangesAsync();
            return matricula;

        }

        public async Task<Matricula> Atualizar(Matricula matricula)
        {
            _appDbContext.Matriculas.Update(matricula);
            await _appDbContext.SaveChangesAsync();
            return matricula;
        }

        public async Task<Matricula> BuscarPorId(int id)
        {
            var matricula = await _appDbContext.Matriculas.FindAsync(id);
            if (matricula == null)
                throw new KeyNotFoundException("Matricula não encontrada");
            return matricula;
        }

        public async Task<bool> Excluir(int id)
        {
            var matricula = await _appDbContext.Matriculas.FindAsync(id);
            if (matricula == null)
                return false;

            _appDbContext.Matriculas.Remove(matricula);
            await _appDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Matricula>> ListarTodos()
        {
            return await _appDbContext.Matriculas.ToListAsync();
        }
    }
}
