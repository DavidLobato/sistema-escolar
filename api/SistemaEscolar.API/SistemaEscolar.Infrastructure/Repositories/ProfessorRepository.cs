
using Microsoft.EntityFrameworkCore;
using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Domain.Interfaces;
using SistemaEscolar.Infrastructure.Data;

namespace SistemaEscolar.Infrastructure.Repositories
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProfessorRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Professor> Adicionar(Professor professor)
        {
            await _appDbContext.Professores.AddAsync(professor);
            await _appDbContext.SaveChangesAsync();
            return professor;
        }

        public async Task<Professor> Atualizar(Professor professor)
        {
            _appDbContext.Professores.Update(professor);
            await _appDbContext.SaveChangesAsync();
            return professor;
        }

        public async Task<Professor> BuscarPorId(int id)
        {
            var professor = await _appDbContext.Professores.FindAsync(id);
            if (professor == null)
                throw new KeyNotFoundException("Professor não encontrado");
            return professor;
        }

        public async Task<bool> Excluir(int id)
        {
            var professor = await _appDbContext.Professores.FindAsync(id);
            if (professor == null)
                return false;

            _appDbContext.Remove(professor);
            await _appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Professor>> ListarTodos()
        {
            return await _appDbContext.Professores.ToListAsync();
        }
    }
}
