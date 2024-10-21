using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Domain.Interfaces;
using SistemaEscolar.Services.Interfaces;

namespace SistemaEscolar.Services.Implementations
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        public FuncionarioService(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        public async Task<Funcionario> Adicionar(Funcionario funcionario)
        {
            return await _funcionarioRepository.Adicionar(funcionario);
        }

        public async Task<Funcionario> Atualizar(Funcionario funcionario)
        {
            return await _funcionarioRepository.Atualizar(funcionario);
        }

        public async Task<Funcionario> BuscarPorId(int id)
        {
            return await _funcionarioRepository.BuscarPorId(id);
        }

        public async Task<bool> Excluir(int id)
        {
            return await _funcionarioRepository.Excluir(id);
        }

        public async Task<IEnumerable<Funcionario>> ListarTodos()
        {
            return await _funcionarioRepository.ListarTodos();
        }
    }
}
