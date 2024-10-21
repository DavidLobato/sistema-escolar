using Microsoft.EntityFrameworkCore;
using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Domain.Interfaces;
using SistemaEscolar.Infrastructure.Data;

namespace SistemaEscolar.Infrastructure.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly AppDbContext _appDbContext;

        public FuncionarioRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Funcionario> Adicionar(Funcionario funcionario)
        {
            await _appDbContext.Funcionarios.AddAsync(funcionario);
            await _appDbContext.SaveChangesAsync();
            return funcionario;
        }

        public async Task<Funcionario> Atualizar(Funcionario funcionario)
        {
            _appDbContext.Funcionarios.Update(funcionario);
            await _appDbContext.SaveChangesAsync();
            return funcionario;
        }

        public async Task<Funcionario> BuscarPorId(int id)
        {
            var funcionario = await _appDbContext.Funcionarios.FindAsync(id);
            if (funcionario == null)
                throw new KeyNotFoundException("Funcionário não encontrado");
            return funcionario;
        }

        public async Task<bool> Excluir(int id)
        {
            var funcionario = await _appDbContext.Funcionarios.FindAsync(id);
            if (funcionario == null)
                return false;

            _appDbContext.Funcionarios.Remove(funcionario);
            await _appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Funcionario>> ListarTodos()
        {
            return await _appDbContext.Funcionarios.ToListAsync();
        }
    }
}
