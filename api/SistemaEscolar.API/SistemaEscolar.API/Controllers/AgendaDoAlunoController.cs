using Microsoft.AspNetCore.Mvc;
using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Services.Interfaces;

namespace SistemaEscolar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaDoAlunoController : ControllerBase
    {
        private readonly IAgendaDoAlunoService _agendaDoAlunoService;
        public AgendaDoAlunoController(IAgendaDoAlunoService agendaDoAlunoService)
        {
            _agendaDoAlunoService = agendaDoAlunoService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var agendasDosAlunos = await _agendaDoAlunoService.ListarTodos();
            return Ok(agendasDosAlunos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            var agendaDoAluno = await _agendaDoAlunoService.BuscarPorId(id);
            if (agendaDoAluno == null)
                return NotFound("Agenda não encontrada.");

            return Ok(agendaDoAluno);
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] AgendaDoAluno agendaDoAluno)
        {
            if (agendaDoAluno == null)
                return BadRequest("Dados da agenda são inválidos.");

            var novaAgenda = await _agendaDoAlunoService.Adicionar(agendaDoAluno);
            return CreatedAtAction(nameof(BuscarPorId), new { id = novaAgenda.Id }, novaAgenda);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] AgendaDoAluno agendaDoAluno)
        {
            if (id != agendaDoAluno.Id)
                return BadRequest("ID da agenda não corresponde.");

            var agendaAtualizada = await _agendaDoAlunoService.Atualizar(agendaDoAluno);
            return Ok(agendaAtualizada);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            await _agendaDoAlunoService.Excluir(id);
            return NoContent();
        }
    }
}
