using Microsoft.EntityFrameworkCore;
using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Domain.Interfaces;
using SistemaEscolar.Infrastructure.Data;

namespace SistemaEscolar.Infrastructure.Repositories
{
    public class DisciplinaRepository : IDisciplinaRepository
    {
        private readonly AppDbContext _appDbContext;

        public DisciplinaRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Disciplina> Adicionar(Disciplina disciplina)
        {
            await _appDbContext.Disciplinas.AddAsync(disciplina);
            await _appDbContext.SaveChangesAsync();
            return disciplina;
        }

        public async Task<Disciplina> Atualizar(Disciplina disciplina)
        {
            _appDbContext.Disciplinas.Update(disciplina);
            await _appDbContext.SaveChangesAsync();
            return disciplina;
        }

        public async Task<Disciplina> BuscarPorId(int id)
        {
            var disciplina = await _appDbContext.Disciplinas.FindAsync(id);
            if (disciplina == null)
                throw new KeyNotFoundException("Disciplina não encontrada");
            return disciplina;
        }

        public async Task<bool> Excluir(int id)
        {
            var disciplina = await _appDbContext.Disciplinas.FindAsync(id);
            if (disciplina == null)
                return false;
            _appDbContext.Disciplinas.Remove(disciplina);
            await _appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Disciplina>> ListarTodos()
        {
            return await _appDbContext.Disciplinas.ToListAsync();
        }
    }
}
