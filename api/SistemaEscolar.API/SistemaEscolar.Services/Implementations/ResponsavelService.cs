using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Domain.Interfaces;
using SistemaEscolar.Services.Interfaces;

namespace SistemaEscolar.Services.Implementations
{
    public class ResponsavelService : IResponsavelService
    {
        private readonly IResponsavelRepository _responsavelRepository;


        public ResponsavelService(IResponsavelRepository responsavelRepository)
        {
            _responsavelRepository = responsavelRepository;
        }

        public async Task<Responsavel> Adicionar(Responsavel responsavel)
        {
            return await _responsavelRepository.Adicionar(responsavel);
        }

        public async Task<Responsavel> Atualizar(Responsavel responsavel)
        {
            return await _responsavelRepository.Atualizar(responsavel);
        }

        public async Task<Responsavel> BuscarPorId(int id)
        {
            return await _responsavelRepository.BuscarPorId(id);
        }

        public async Task<bool> Excluir(int id)
        {
            return await _responsavelRepository.Excluir(id);
        }

        public async Task<IEnumerable<Responsavel>> ListarTodos()
        {
            return await _responsavelRepository.ListarTodos();
        }
    }
}
