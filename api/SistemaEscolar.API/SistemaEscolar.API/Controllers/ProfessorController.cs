using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Services.Interfaces;

namespace SistemaEscolar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorServices _professorServices;
        public ProfessorController(IProfessorServices professorServices)
        {
            _professorServices = professorServices;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var professores = await _professorServices.ListarTodos();
            return Ok(professores);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            var professor = await _professorServices.BuscarPorId(id);
            if (professor == null)
                return NotFound("Professor não encontrado.");

            return Ok(professor);
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] Professor professor)
        {
            if (professor == null)
                return BadRequest("Dados do professor são inválidos.");

            var novoProfessor = await _professorServices.Adicionar(professor);
            return CreatedAtAction(nameof(BuscarPorId), new { id = novoProfessor.Id }, novoProfessor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] Professor professor)
        {
            if (id != professor.Id)
                return BadRequest("ID do professor não corresponde.");

            var alunoAtualizado = await _professorServices.Atualizar(professor);
            return Ok(alunoAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            await _professorServices.Excluir(id);
            return NoContent();
        }
    }
}
