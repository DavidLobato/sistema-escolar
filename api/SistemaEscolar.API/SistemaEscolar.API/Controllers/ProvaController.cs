using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Services.Interfaces;

namespace SistemaEscolar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvaController : ControllerBase
    {
        private readonly IProvaService _provaService;

        public ProvaController(IProvaService provaService)
        {
            _provaService = provaService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var alunos = await _provaService.ListarTodos();
            return Ok(alunos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            var prova = await _provaService.BuscarPorId(id);
            if (prova == null)
                return NotFound("Prova não encontrada.");

            return Ok(prova);
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] Prova prova)
        {
            if (prova == null)
                return BadRequest("Dados da prova são inválidos.");

            var novaProva = await _provaService.Adicionar(prova);
            return CreatedAtAction(nameof(BuscarPorId), new { id = novaProva.Id }, novaProva);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] Prova prova)
        {
            if (id != prova.Id)
                return BadRequest("ID da prova não corresponde.");

            var provaAtualizada = await _provaService.Atualizar(prova);
            return Ok(provaAtualizada);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            await _provaService.Excluir(id);
            return NoContent();
        }
    }
}
