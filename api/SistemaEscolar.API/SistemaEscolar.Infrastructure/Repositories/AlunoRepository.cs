using Microsoft.EntityFrameworkCore;
using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Domain.Interfaces;
using SistemaEscolar.Infrastructure.Data;


namespace SistemaEscolar.Infrastructure.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly AppDbContext _context;

        public AlunoRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Aluno> Adicionar(Aluno aluno)
        {
            await _context.Alunos.AddAsync(aluno);
            await _context.SaveChangesAsync();
            return aluno;

        }

        public async Task<Aluno> Atualizar(Aluno aluno)
        {
            _context.Alunos.Update(aluno);
            await _context.SaveChangesAsync();
            return aluno;
        }

        public async Task<Aluno> BuscarPorId(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null)
                throw new KeyNotFoundException("Aluno não encontrado");
            return aluno;
        }

        public async Task<bool> Excluir(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null)
                return false;

            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Aluno>> ListarTodos()
        {
            return await _context.Alunos.ToListAsync();
        }
    }
}
