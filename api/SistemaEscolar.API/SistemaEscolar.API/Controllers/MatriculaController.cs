using Microsoft.AspNetCore.Mvc;
using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Services.Interfaces;

namespace SistemaEscolar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatriculaController : ControllerBase
    {
        private readonly IMatriculaService _matriculaService;

        public MatriculaController(IMatriculaService matriculaService)
        {
            _matriculaService = matriculaService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var alunos = await _matriculaService.ListarTodos();
            return Ok(alunos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            var matricula = await _matriculaService.BuscarPorId(id);
            if (matricula == null)
                return NotFound("Matricula não encontrada.");

            return Ok(matricula);
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] Matricula matricula)
        {
            if (matricula == null)
                return BadRequest("Dados da matricula são inválidos.");

            var novaMatricula = await _matriculaService.Adicionar(matricula);
            return CreatedAtAction(nameof(BuscarPorId), new { id = novaMatricula.Id }, novaMatricula);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] Matricula matricula)
        {
            if (id != matricula.Id)
                return BadRequest("ID da matricula não corresponde.");

            var matriculaAtualizada = await _matriculaService.Atualizar(matricula);
            return Ok(matriculaAtualizada);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            await _matriculaService.Excluir(id);
            return NoContent();
        }
    }
}
