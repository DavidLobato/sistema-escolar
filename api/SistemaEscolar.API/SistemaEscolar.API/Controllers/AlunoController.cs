using Microsoft.AspNetCore.Mvc;
using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Services.Interfaces;

namespace SistemaEscolar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoService _alunoService;
        public AlunoController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var alunos = await _alunoService.ListarTodos();
            return Ok(alunos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            var aluno = await _alunoService.BuscarPorId(id);
            if (aluno == null)
                return NotFound("Aluno não encontrado.");

            return Ok(aluno);
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] Aluno aluno)
        {
            if (aluno == null)
                return BadRequest("Dados do aluno são inválidos.");

            var novoAluno = await _alunoService.Adicionar(aluno);
            return CreatedAtAction(nameof(BuscarPorId), new { id = novoAluno.Id }, novoAluno);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] Aluno aluno)
        {
            if (id != aluno.Id)
                return BadRequest("ID do aluno não corresponde.");

            var alunoAtualizado = await _alunoService.Atualizar(aluno);
            return Ok(alunoAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            await _alunoService.Excluir(id);
            return NoContent();
        }
    }
}
