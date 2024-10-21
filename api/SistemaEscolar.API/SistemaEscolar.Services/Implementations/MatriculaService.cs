using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Services.Interfaces;

namespace SistemaEscolar.Services.Implementations
{
    public class MatriculaService : IMatriculaService
    {
        private readonly IMatriculaService _matriculaService;
        public MatriculaService(IMatriculaService matriculaService)
        {
            _matriculaService = matriculaService;
        }

        public async Task<Matricula> Adicionar(Matricula matricula)
        {
            return await _matriculaService.Adicionar(matricula);
        }

        public async Task<Matricula> Atualizar(Matricula matricula)
        {
            return await _matriculaService.Atualizar(matricula);
        }

        public async Task<Matricula> BuscarPorId(int id)
        {
            return await _matriculaService.BuscarPorId(id);
        }

        public async Task<bool> Excluir(int id)
        {
            return await _matriculaService.Excluir(id);
        }

        public async Task<IEnumerable<Matricula>> ListarTodos()
        {
            return await _matriculaService.ListarTodos();
        }
    }
}
