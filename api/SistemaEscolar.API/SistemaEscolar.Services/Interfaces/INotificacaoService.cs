using SistemaEscolar.Domain.Entities;

namespace SistemaEscolar.Services.Interfaces
{
    public interface INotificacaoService
    {
        Task<Notificacao> BuscarPorId(int id);
        Task<IEnumerable<Notificacao>> ListarTodos();
        Task<Notificacao> Adicionar(Notificacao notificacao);
        Task<Notificacao> Atualizar(Notificacao notificacao);
        Task<bool> Excluir(int id);
    }
}
