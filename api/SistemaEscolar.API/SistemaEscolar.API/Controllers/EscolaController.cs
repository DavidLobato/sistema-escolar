using Microsoft.AspNetCore.Mvc;
using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Services.Interfaces;

namespace SistemaEscolar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EscolaController : ControllerBase
    {
        private readonly IEscolaService _escolaService;
        public EscolaController(IEscolaService escolaService)
        {
            _escolaService = escolaService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var escolas = await _escolaService.ListarTodos();
            return Ok(escolas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            var escola = await _escolaService.BuscarPorId(id);
            if (escola == null)
                return NotFound("Escola não encontrada.");

            return Ok(escola);
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] Escola escola)
        {
            if (escola == null)
                return BadRequest("Dados do aluno são inválidos.");

            var novaEscola = await _escolaService.Adicionar(escola);
            return CreatedAtAction(nameof(BuscarPorId), new { id = novaEscola.Id }, novaEscola);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] Escola escola)
        {
            if (id != escola.Id)
                return BadRequest("ID do aluno não corresponde.");

            var escolaAtualizada = await _escolaService.Atualizar(escola);
            return Ok(escolaAtualizada);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            await _escolaService.Excluir(id);
            return NoContent();
        }
    }
}
