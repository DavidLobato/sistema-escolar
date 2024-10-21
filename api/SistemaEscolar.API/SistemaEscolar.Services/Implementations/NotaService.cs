using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Domain.Interfaces;
using SistemaEscolar.Services.Interfaces;

namespace SistemaEscolar.Services.Implementations
{
    public class NotaService : INotaService
    {
        private readonly INotaRepository _notaRepository;
        public NotaService(INotaRepository notaRepository)
        {
            _notaRepository = notaRepository;
        }

        public async Task<Nota> Adicionar(Nota nota)
        {
            return await _notaRepository.Adicionar(nota);
        }

        public async Task<Nota> Atualizar(Nota nota)
        {
            return await _notaRepository.Atualizar(nota);
        }

        public async Task<Nota> BuscarPorId(int id)
        {
            return await _notaRepository.BuscarPorId(id);
        }

        public async Task<bool> Excluir(int id)
        {
            return await _notaRepository.Excluir(id);
        }

        public async Task<IEnumerable<Nota>> ListarTodos()
        {
            return await _notaRepository.ListarTodos();
        }
    }
}
