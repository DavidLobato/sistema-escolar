using Microsoft.EntityFrameworkCore;
using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Domain.Interfaces;
using SistemaEscolar.Infrastructure.Data;

namespace SistemaEscolar.Infrastructure.Repositories
{
    public class TurmaRepository : ITurmaRepository
    {
        private readonly AppDbContext _appDbContext;

        public TurmaRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Turma> Adicionar(Turma turma)
        {
            await _appDbContext.Turmas.AddAsync(turma);
            await _appDbContext.SaveChangesAsync();
            return turma;
        }

        public async Task<Turma> Atualizar(Turma turma)
        {
            _appDbContext.Turmas.Update(turma);
            await _appDbContext.SaveChangesAsync();
            return turma;

        }

        public async Task<Turma> BuscarPorId(int id)
        {
            var turma = await _appDbContext.Turmas.FindAsync(id);
            if (turma == null)
                throw new KeyNotFoundException("Turma não encontrada");
            return turma;
        }

        public async Task<bool> Excluir(int id)
        {
            var turma = await _appDbContext.Turmas.FindAsync(id);
            if (turma == null)
                return false;

            _appDbContext.Turmas.Remove(turma);
            await _appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Turma>> ListarTodos()
        {
            return await _appDbContext.Turmas.ToListAsync();
        }
    }
}
