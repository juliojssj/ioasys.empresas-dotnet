using Ioasys.Domain.FilmeAggregate.Dtos;
using Ioasys.Domain.FilmeAggregate.Services;
using Ioasys.Domain.Shared.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ioasys.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeService _filmeService;
        private readonly IVotoService _votoService;

        private HATEOAS.HATEOAS HATEOAS;

        public FilmeController(IFilmeService filmeService, IVotoService votoService)
        {
            _filmeService = filmeService;
            _votoService = votoService;
        }

        /// <summary>
        /// Registrar filme no sistema
        /// </summary>
        /// <response code="201"></response>
        [HttpPost]
        public IActionResult RegistraFilme([FromBody] FilmeRegistroDto filmeRegistroDto)
        {
            _filmeService.RegistraFilme(filmeRegistroDto);

            return Created($"{nameof(FilmeController)}", new { });
        }

        /// <summary>
        /// Votar em um determinado filme.
        /// </summary>
        /// <response code="200"></response>
        [HttpPost("voto")]
        public IActionResult VotoRating([FromBody] RatingFilme ratingFilme)
        {
            _votoService.VotoRating(ratingFilme);

            return Ok();
        }

        /// <summary>
        /// Listagem dos filmes
        /// </summary>
        /// <response code="200"></response>
        [HttpGet]
        public IActionResult BuscaFilmes([FromQuery] BuscaFilme busca)
        {
            var result = _filmeService.BuscaFilmes(busca);

            return Ok(result.Items);
        }


        /// <summary>
        /// Buscar por um filme
        /// </summary>
        /// <response code="200"></response>
        [HttpGet("{idFilme}")]
        public IActionResult BuscaFilmes([FromRoute] int idFilme)
        {
            var result = _filmeService.BuscaFilme(idFilme);

            return Ok(result);
        }
    }
}
