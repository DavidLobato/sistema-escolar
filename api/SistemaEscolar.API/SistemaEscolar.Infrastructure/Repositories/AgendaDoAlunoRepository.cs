using Microsoft.EntityFrameworkCore;
using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Domain.Interfaces;
using SistemaEscolar.Infrastructure.Data;

namespace SistemaEscolar.Infrastructure.Repositories
{
    public class AgendaDoAlunoRepository : IAgendaDoAlunoRepository
    {
        private readonly AppDbContext _appDbContext;

        public AgendaDoAlunoRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<AgendaDoAluno> Adicionar(AgendaDoAluno agendaDoAluno)
        {
            await _appDbContext.AgendasDosAlunos.AddAsync(agendaDoAluno);
            await _appDbContext.SaveChangesAsync();
            return agendaDoAluno;
        }

        public async Task<AgendaDoAluno> Atualizar(AgendaDoAluno agendaDoAluno)
        {
            _appDbContext.Update(agendaDoAluno);
            await _appDbContext.SaveChangesAsync();
            return agendaDoAluno;

        }

        public async Task<AgendaDoAluno> BuscarPorId(int id)
        {
            var agendaDoAluno = await _appDbContext.AgendasDosAlunos.FindAsync(id);
            if (agendaDoAluno == null)
                throw new ArgumentException("Agenda não encontrada");
            return agendaDoAluno;
        }

        public async Task<bool> Excluir(int id)
        {
            var agendaDoAluno = await _appDbContext.AgendasDosAlunos.FindAsync(id);
            if (agendaDoAluno == null)
                return false;

            _appDbContext.AgendasDosAlunos.Remove(agendaDoAluno);
            await _appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<AgendaDoAluno>> ListarTodos()
        {
            return await _appDbContext.AgendasDosAlunos.ToListAsync();
        }
    }
}
