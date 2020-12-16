using Ioasys.Domain.AuthAggregate.Dtos;
using Ioasys.Domain.AuthAggregate.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ioasys.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        private HATEOAS.HATEOAS HATEOAS;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        /// <summary>
        /// Registrar um usuário
        /// </summary>
        /// <response code="201"></response>
        [HttpPost]
        [AllowAnonymous]
        public IActionResult RegistraUsuario([FromBody] UsuarioRegistroDto usuarioRegistroDto)
        {
            _usuarioService.RegistraUsuario(usuarioRegistroDto);

            return Created($"{nameof(UsuarioController)}", new {});
        }

        /// <summary>
        /// Atualizar os dados de um usuário
        /// </summary>
        /// <response code="200"></response>
        [HttpPut]
        public IActionResult AtualizaUsuario([FromBody] UsuarioAtualizaDto usuarioAtualizaDto)
        {
            _usuarioService.AtualizaUsuario(usuarioAtualizaDto);

            return Ok();
        }

        /// <summary>
        /// Desativar o usuário logado.
        /// </summary>
        /// <response code="200"></response>
        [HttpDelete("desativar")]
        public IActionResult DesativarUsuario()
        {
            _usuarioService.DesativaUsuario();

            return Ok();
        }
    }
}
