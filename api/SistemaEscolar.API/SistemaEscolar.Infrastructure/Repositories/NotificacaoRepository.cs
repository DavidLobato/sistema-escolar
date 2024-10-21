using Microsoft.EntityFrameworkCore;
using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Domain.Interfaces;
using SistemaEscolar.Infrastructure.Data;

namespace SistemaEscolar.Infrastructure.Repositories
{
    public class NotificacaoRepository : INotificacaoRepository
    {
        private readonly AppDbContext _appDbContext;

        public NotificacaoRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Notificacao> Adicionar(Notificacao notificacao)
        {
            await _appDbContext.Notificacoes.AddAsync(notificacao);
            await _appDbContext.SaveChangesAsync();
            return notificacao;
        }

        public async Task<Notificacao> Atualizar(Notificacao notificacao)
        {
            _appDbContext.Notificacoes.Update(notificacao);
            await _appDbContext.SaveChangesAsync();
            return notificacao;
        }

        public async Task<Notificacao> BuscarPorId(int id)
        {
            var notificacao = await _appDbContext.Notificacoes.FindAsync(id);
            if (notificacao == null)
                throw new KeyNotFoundException("Notificação não encontrada");
            return notificacao;
        }

        public async Task<bool> Excluir(int id)
        {
            var notificacao = await _appDbContext.Notificacoes.FindAsync(id);
            if (notificacao == null)
                return false;

            _appDbContext.Notificacoes.Remove(notificacao);
            await _appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Notificacao>> ListarTodos()
        {
            return await _appDbContext.Notificacoes.ToListAsync();
        }
    }
}
