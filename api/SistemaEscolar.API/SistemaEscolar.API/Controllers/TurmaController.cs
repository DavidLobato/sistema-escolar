using Microsoft.AspNetCore.Mvc;
using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Services.Interfaces;

namespace SistemaEscolar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        private readonly ITurmaService _turmaService;

        public TurmaController(ITurmaService turmaService)
        {
            _turmaService = turmaService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var turmas = await _turmaService.ListarTodos();
            return Ok(turmas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            var turma = await _turmaService.BuscarPorId(id);
            if (turma == null)
                return NotFound("Turma não encontrada.");

            return Ok(turma);
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] Turma turma)
        {
            if (turma == null)
                return BadRequest("Dados da turma são inválidos.");

            var novaTurma = await _turmaService.Adicionar(turma);
            return CreatedAtAction(nameof(BuscarPorId), new { id = novaTurma.Id }, novaTurma);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] Turma turma)
        {
            if (id != turma.Id)
                return BadRequest("ID da turma não corresponde.");

            var turmaAtualizada = await _turmaService.Atualizar(turma);
            return Ok(turmaAtualizada);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            await _turmaService.Excluir(id);
            return NoContent();
        }
    }
}
