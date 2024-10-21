using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Domain.Interfaces;
using SistemaEscolar.Services.Interfaces;

namespace SistemaEscolar.Services.Implementations
{
    public class EscolaService : IEscolaService
    {
        private readonly IEscolaRepository _escolaRepository;
        public EscolaService(IEscolaRepository escolaRepository)
        {
            _escolaRepository = escolaRepository;
        }

        public async Task<Escola> Adicionar(Escola escola)
        {
            return await _escolaRepository.Adicionar(escola);
        }

        public async Task<Escola> Atualizar(Escola escola)
        {
            return await _escolaRepository.Atualizar(escola);
        }

        public async Task<Escola> BuscarPorId(int id)
        {
            return await _escolaRepository.BuscarPorId(id);
        }

        public async Task<bool> Excluir(int id)
        {
            return await _escolaRepository.Excluir(id);
        }

        public Task<IEnumerable<Escola>> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
