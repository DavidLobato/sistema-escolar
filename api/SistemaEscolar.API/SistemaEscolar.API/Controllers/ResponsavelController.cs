using Microsoft.AspNetCore.Mvc;
using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Services.Interfaces;

namespace SistemaEscolar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponsavelController : ControllerBase
    {
        private readonly IResponsavelService _responsavelService;

        public ResponsavelController(IResponsavelService responsavelService)
        {
            _responsavelService = responsavelService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var responsaveis = await _responsavelService.ListarTodos();
            return Ok(responsaveis);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            var responsavel = await _responsavelService.BuscarPorId(id);
            if (responsavel == null)
                return NotFound("Responsável não encontrado.");

            return Ok(responsavel);
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] Responsavel responsavel)
        {
            if (responsavel == null)
                return BadRequest("Dados do responsável são inválidos.");

            var novoResponsavel = await _responsavelService.Adicionar(responsavel);
            return CreatedAtAction(nameof(BuscarPorId), new { id = novoResponsavel.Id }, novoResponsavel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] Responsavel responsavel)
        {
            if (id != responsavel.Id)
                return BadRequest("ID do responsável não corresponde.");

            var responsavelAtualizado = await _responsavelService.Atualizar(responsavel);
            return Ok(responsavelAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            await _responsavelService.Excluir(id);
            return NoContent();
        }
    }
}
