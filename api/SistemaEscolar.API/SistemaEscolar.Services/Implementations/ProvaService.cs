using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Domain.Interfaces;
using SistemaEscolar.Infrastructure.RabbitMQ;
using SistemaEscolar.Services.Interfaces;

namespace SistemaEscolar.Services.Implementations
{
    public class ProvaService : IProvaService
    {
        private readonly IProvaRepository _provaRepository;
        private readonly RabbitMqService _rabbitMqService;

        public ProvaService(IProvaRepository provaRepository, RabbitMqService rabbitMqService)
        {
            _provaRepository = provaRepository;
            _rabbitMqService = rabbitMqService;
        }

        public async Task<Prova> Adicionar(Prova prova)
        {
            return await _provaRepository.Adicionar(prova);
        }

        public async Task<Prova> Atualizar(Prova prova)
        {
            return await _provaRepository.Atualizar(prova);
        }

        public async Task<Prova> BuscarPorId(int id)
        {
            return await _provaRepository.BuscarPorId(id);
        }

        public async Task<bool> Excluir(int id)
        {
            return await _provaRepository.Excluir(id);
        }

        public async Task<IEnumerable<Prova>> ListarTodos()
        {
            return await _provaRepository.ListarTodos();
        }
    }
}
