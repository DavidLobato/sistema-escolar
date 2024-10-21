using Microsoft.AspNetCore.Mvc;
using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Services.Interfaces;

namespace SistemaEscolar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var usuarios = await _usuarioService.ListarTodos();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            var usuario = await _usuarioService.BuscarPorId(id);
            if (usuario == null)
                return NotFound("Usuário não encontrado.");

            return Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] Usuario usuario)
        {
            if (usuario == null)
                return BadRequest("Dados do usuário são inválidos.");

            var novoUsuario = await _usuarioService.Adicionar(usuario);
            return CreatedAtAction(nameof(BuscarPorId), new { id = novoUsuario.Id }, novoUsuario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] Usuario usuario)
        {
            if (id != usuario.Id)
                return BadRequest("ID do usuário não corresponde.");

            var usuarioAtualizado = await _usuarioService.Atualizar(usuario);
            return Ok(usuarioAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            await _usuarioService.Excluir(id);
            return NoContent();
        }
    }
}
