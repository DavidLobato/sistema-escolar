using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Domain.Interfaces;
using SistemaEscolar.Infrastructure.RabbitMQ;
using SistemaEscolar.Services.Interfaces;

namespace SistemaEscolar.Services.Implementations
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly RabbitMqService _rabbitMqService;
        public AlunoService(IAlunoRepository alunoRepository, RabbitMqService rabbitMqService)
        {
            _alunoRepository = alunoRepository;
            _rabbitMqService = rabbitMqService;
        }

        public async Task<Aluno> Adicionar(Aluno aluno)
        {
            var novoAluno = await _alunoRepository.Adicionar(aluno);
            _rabbitMqService.Publish($"Novo aluno cadastrado: {novoAluno.Nome}");

            return novoAluno;

        }

        public async Task<Aluno> Atualizar(Aluno aluno)
        {
            return await _alunoRepository.Atualizar(aluno);
        }

        public async Task<Aluno> BuscarPorId(int id)
        {
            return await _alunoRepository.BuscarPorId(id);
        }

        public async Task<bool> Excluir(int id)
        {
            return await _alunoRepository.Excluir(id);
        }

        public async Task<IEnumerable<Aluno>> ListarTodos()
        {
            return await _alunoRepository.ListarTodos();
        }
    }
}
