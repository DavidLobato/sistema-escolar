using Microsoft.AspNetCore.Mvc;
using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Services.Interfaces;

namespace SistemaEscolar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinaController : ControllerBase
    {
        private readonly IDisciplinaService _disciplinaService;
        public DisciplinaController(IDisciplinaService disciplinaService)
        {
            _disciplinaService = disciplinaService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var alunos = await _disciplinaService.ListarTodos();
            return Ok(alunos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            var aluno = await _disciplinaService.BuscarPorId(id);
            if (aluno == null)
                return NotFound("Disciplin não encontrada.");

            return Ok(aluno);
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] Disciplina disciplina)
        {
            if (disciplina == null)
                return BadRequest("Dados da disciplina são inválidos.");

            var novaDisciplina = await _disciplinaService.Adicionar(disciplina);
            return CreatedAtAction(nameof(BuscarPorId), new { id = novaDisciplina.Id }, novaDisciplina);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] Disciplina disciplina)
        {
            if (id != disciplina.Id)
                return BadRequest("ID da disciplina não corresponde.");

            var disciplinaAtualizada = await _disciplinaService.Atualizar(disciplina);
            return Ok(disciplinaAtualizada);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            await _disciplinaService.Excluir(id);
            return NoContent();
        }
    }
}
