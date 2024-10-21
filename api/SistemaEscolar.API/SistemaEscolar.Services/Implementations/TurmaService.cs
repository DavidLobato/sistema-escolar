using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Domain.Interfaces;
using SistemaEscolar.Services.Interfaces;

namespace SistemaEscolar.Services.Implementations
{
    public class TurmaService : ITurmaService
    {
        private readonly ITurmaRepository _turmaRepository;

        public TurmaService(ITurmaRepository turmaRepository)
        {
            _turmaRepository = turmaRepository;
        }

        public async Task<Turma> Adicionar(Turma turma)
        {
            return await _turmaRepository.Adicionar(turma);
        }

        public async Task<Turma> Atualizar(Turma turma)
        {
            return await _turmaRepository.Atualizar(turma);
        }

        public async Task<Turma> BuscarPorId(int id)
        {
            return await _turmaRepository.BuscarPorId(id);
        }

        public async Task<bool> Excluir(int id)
        {
            return await _turmaRepository.Excluir(id);
        }

        public async Task<IEnumerable<Turma>> ListarTodos()
        {
            return await _turmaRepository.ListarTodos();
        }
    }
}
