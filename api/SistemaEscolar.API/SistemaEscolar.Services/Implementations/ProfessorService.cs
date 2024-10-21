using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Domain.Interfaces;
using SistemaEscolar.Infrastructure.RabbitMQ;
using SistemaEscolar.Services.Interfaces;

namespace SistemaEscolar.Services.Implementations
{
    public class ProfessorService : IProfessorServices
    {

        private readonly IProfessorRepository _professorRepository;
        private readonly RabbitMqService _rabbitMqService;
        public ProfessorService(IProfessorRepository professorRepository, RabbitMqService rabbitMqService)
        {
            _professorRepository = professorRepository;
            _rabbitMqService = rabbitMqService;
        }

        public async Task<Professor> Adicionar(Professor professor)
        {
            var novoProfessor = await _professorRepository.Adicionar(professor);
            _rabbitMqService.Publish($"Novo professor cadastrado{professor.Nome}");
            return novoProfessor;
        }

        public async Task<Professor> Atualizar(Professor professor)
        {
            return await _professorRepository.Atualizar(professor);
        }

        public async Task<Professor> BuscarPorId(int id)
        {
            return await _professorRepository.BuscarPorId(id);
        }

        public async Task<bool> Excluir(int id)
        {
            return await _professorRepository.Excluir(id);
        }

        public async Task<IEnumerable<Professor>> ListarTodos()
        {
            return await _professorRepository.ListarTodos();
        }
    }
}
