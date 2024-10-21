using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Domain.Interfaces;
using SistemaEscolar.Services.Interfaces;

namespace SistemaEscolar.Services.Implementations
{
    public class AgendaDoAlunoService : IAgendaDoAlunoService
    {
        private readonly IAgendaDoAlunoRepository _agendaDoAlunoRepository;
        public AgendaDoAlunoService(IAgendaDoAlunoRepository agendaDoAlunoRepository)
        {
            _agendaDoAlunoRepository = agendaDoAlunoRepository;
        }

        public async Task<AgendaDoAluno> Adicionar(AgendaDoAluno agendaDoAluno)
        {
            return await _agendaDoAlunoRepository.Adicionar(agendaDoAluno);
        }

        public async Task<AgendaDoAluno> Atualizar(AgendaDoAluno agendaDoAluno)
        {
            return await _agendaDoAlunoRepository.Atualizar(agendaDoAluno);
        }

        public async Task<AgendaDoAluno> BuscarPorId(int id)
        {
            return await _agendaDoAlunoRepository.BuscarPorId(id);
        }

        public async Task<bool> Excluir(int id)
        {
            return await _agendaDoAlunoRepository.Excluir(id);
        }

        public async Task<IEnumerable<AgendaDoAluno>> ListarTodos()
        {
            return await _agendaDoAlunoRepository.ListarTodos();
        }
    }
}
