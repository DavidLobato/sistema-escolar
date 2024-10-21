using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Services.Interfaces;

namespace SistemaEscolar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService _pessoaService;
        public PessoaController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var pessoas = await _pessoaService.ListarTodos();
            return Ok(pessoas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            var pessoa = await _pessoaService.BuscarPorId(id);
            if (pessoa == null)
                return NotFound("Pessoa não encontrada.");

            return Ok(pessoa);
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] Pessoa pessoa)
        {
            if (pessoa == null)
                return BadRequest("Dados da pessoa são inválidos.");

            var novaPessoa = await _pessoaService.Adicionar(pessoa);
            return CreatedAtAction(nameof(BuscarPorId), new { id = novaPessoa.Id }, novaPessoa);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] Pessoa pessoa)
        {
            if (id != pessoa.Id)
                return BadRequest("ID da pessoa não corresponde.");

            var pessoaAtualizada = await _pessoaService.Atualizar(pessoa);
            return Ok(pessoaAtualizada);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            await _pessoaService.Excluir(id);
            return NoContent();
        }
    }
}
