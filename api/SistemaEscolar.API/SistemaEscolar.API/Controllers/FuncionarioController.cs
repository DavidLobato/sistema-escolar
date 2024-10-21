using Microsoft.AspNetCore.Mvc;
using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Services.Interfaces;

namespace SistemaEscolar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioService _funcionarioService;

        public FuncionarioController(IFuncionarioService funcionarioService)
        {
            _funcionarioService = funcionarioService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var funcionarios = await _funcionarioService.ListarTodos();
            return Ok(funcionarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            var funcionario = await _funcionarioService.BuscarPorId(id);
            if (funcionario == null)
                return NotFound("Funcionário não encontrado.");

            return Ok(funcionario);
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] Funcionario funcionario)
        {
            if (funcionario == null)
                return BadRequest("Dados do funcionário são inválidos.");

            var novoFuncionario = await _funcionarioService.Adicionar(funcionario);
            return CreatedAtAction(nameof(BuscarPorId), new { id = novoFuncionario.Id }, novoFuncionario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] Funcionario funcionario)
        {
            if (id != funcionario.Id)
                return BadRequest("ID do funcionário não corresponde.");

            var funcionarioAtualizado = await _funcionarioService.Atualizar(funcionario);
            return Ok(funcionarioAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            await _funcionarioService.Excluir(id);
            return NoContent();
        }
    }
}
