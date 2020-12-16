using Ioasys.Domain.AuthAggregate.Dtos;
using Ioasys.Domain.AuthAggregate.Services;
using Ioasys.Domain.Shared.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ioasys.Api.HATEOAS;

namespace Ioasys.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class AdminController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        private HATEOAS.HATEOAS HATEOAS;

        public AdminController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        /// <summary>
        /// Lista de usuários não administradores ativos (registros paginados)
        /// </summary>
        /// <response code="200"></response>
        [HttpGet]
        public IActionResult GetUsuarios([FromQuery] GenericFilter<UsuarioListaDto> busca)
        {
            var result = _usuarioService.BuscaUsuario(busca);

            return Ok(result.Items);
        }

        /// <summary>
        /// Registro de usuário administrador no sistema
        /// </summary>
        /// <response code="201"></response>
        [HttpPost]
        [AllowAnonymous]
        public IActionResult RegistraAdmin([FromBody] AdminRegistroDto adminRegistroDto)
        {
            _usuarioService.RegistraAdmin(adminRegistroDto);

            return Created($"{nameof(Link)}", new {});
        }

        /// <summary>
        /// Edição de usuário administrador.
        /// </summary>
        /// <response code="200"></response>
        [HttpPut]
        public IActionResult AtualizaAdmin([FromBody] UsuarioAtualizaDto usuarioAtualizaDto)
        {
            _usuarioService.AtualizaUsuario(usuarioAtualizaDto);

            return Ok();
        }

        /// <summary>
        /// Desativação de usuários (acesso de administrador)
        /// </summary>
        /// <response code="200"></response>
        [HttpDelete("desativar/{usuarioId}")]
        public IActionResult DesativaAdmin([FromRoute] int usuarioId)
        {
            _usuarioService.DesativaUsuario(usuarioId);

            return Ok();
        }
    }
}
