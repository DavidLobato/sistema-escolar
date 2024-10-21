using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Domain.Interfaces;
using SistemaEscolar.Infrastructure.RabbitMQ;
using SistemaEscolar.Services.Interfaces;

namespace SistemaEscolar.Services.Implementations
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly RabbitMqService _rabbitMqService;
        public PessoaService(IPessoaRepository pessoaRepository, RabbitMqService rabbitMqService)
        {
            _pessoaRepository = pessoaRepository;
            _rabbitMqService = rabbitMqService;
        }

        public async Task<Pessoa> Adicionar(Pessoa pessoa)
        {
            var novaPessoa = await _pessoaRepository.Adicionar(pessoa);
            _rabbitMqService.Publish($"Nova pessoa cadastra:{novaPessoa.Nome} ");

            return novaPessoa;

        }

        public async Task<Pessoa> Atualizar(Pessoa pessoa)
        {
            return await _pessoaRepository.Atualizar(pessoa);
        }

        public async Task<Pessoa> BuscarPorId(int id)
        {
            return await _pessoaRepository.BuscarPorId(id);
        }

        public Task<bool> Excluir(int id)
        {
            return _pessoaRepository.Excluir(id);
        }

        public Task<IEnumerable<Pessoa>> ListarTodos()
        {
            return _pessoaRepository.ListarTodos();
        }
    }
}
