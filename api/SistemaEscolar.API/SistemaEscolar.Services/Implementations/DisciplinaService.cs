
using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Domain.Interfaces;
using SistemaEscolar.Services.Interfaces;

namespace SistemaEscolar.Services.Implementations
{
    public class DisciplinaService : IDisciplinaService
    {
        private readonly IDisciplinaRepository _disciplinaRepository;
        public DisciplinaService(IDisciplinaRepository repository)
        {
            _disciplinaRepository = repository;
        }

        public async Task<Disciplina> Adicionar(Disciplina disciplina)
        {
            return await _disciplinaRepository.Adicionar(disciplina);
        }

        public async Task<Disciplina> Atualizar(Disciplina disciplina)
        {
            return await _disciplinaRepository.Atualizar(disciplina);
        }

        public async Task<Disciplina> BuscarPorId(int id)
        {
            return await _disciplinaRepository.BuscarPorId(id);
        }

        public async Task<bool> Excluir(int id)
        {
            return await _disciplinaRepository.Excluir(id);
        }

        public async Task<IEnumerable<Disciplina>> ListarTodos()
        {
            return await _disciplinaRepository.ListarTodos();
        }
    }
}
