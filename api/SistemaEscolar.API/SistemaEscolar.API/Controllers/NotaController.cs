using Microsoft.AspNetCore.Mvc;
using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Services.Interfaces;

namespace SistemaEscolar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotaController : ControllerBase
    {
        private readonly INotaService _notaService;
        public NotaController(INotaService notaService)
        {
            _notaService = notaService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var notas = await _notaService.ListarTodos();
            return Ok(notas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            var nota = await _notaService.BuscarPorId(id);
            if (nota == null)
                return NotFound("Nota não encontrada.");

            return Ok(nota);
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] Nota nota)
        {
            if (nota == null)
                return BadRequest("Dados da nota são inválidos.");

            var novaNota = await _notaService.Adicionar(nota);
            return CreatedAtAction(nameof(BuscarPorId), new { id = novaNota.Id }, novaNota);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] Nota nota)
        {
            if (id != nota.Id)
                return BadRequest("ID da nota não corresponde.");

            var notaAtualizada = await _notaService.Atualizar(nota);
            return Ok(notaAtualizada);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            await _notaService.Excluir(id);
            return NoContent();
        }
    }
}
