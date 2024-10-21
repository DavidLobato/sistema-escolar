using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Domain.Interfaces;
using SistemaEscolar.Services.Interfaces;

namespace SistemaEscolar.Services.Implementations
{
    public class NotificacaoService : INotificacaoService
    {
        private readonly INotificacaoRepository _notificacaoRepository;
        public NotificacaoService(INotificacaoRepository notificacaoRepository)
        {
            _notificacaoRepository = notificacaoRepository;
        }

        public async Task<Notificacao> Adicionar(Notificacao notificacao)
        {
            return await _notificacaoRepository.Adicionar(notificacao);
        }

        public async Task<Notificacao> Atualizar(Notificacao notificacao)
        {
            return await _notificacaoRepository.Atualizar(notificacao);
        }

        public async Task<Notificacao> BuscarPorId(int id)
        {
            return await _notificacaoRepository.BuscarPorId(id);
        }

        public async Task<bool> Excluir(int id)
        {
            return await _notificacaoRepository.Excluir(id);
        }

        public async Task<IEnumerable<Notificacao>> ListarTodos()
        {
            return await _notificacaoRepository.ListarTodos();
        }
    }
}
