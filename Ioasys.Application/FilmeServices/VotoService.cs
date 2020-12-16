using System.Security.Claims;
using System.Threading.Tasks;
using Ioasys.Domain.FilmeAggregate.Dtos;
using Ioasys.Domain.FilmeAggregate.Entities;
using Ioasys.Domain.FilmeAggregate.Repositories;
using Ioasys.Domain.FilmeAggregate.Services;
using Ioasys.Domain.Properties;
using Ioasys.Domain.Shared.Exceptions;
using Ioasys.Domain.Shared.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Ioasys.Application.FilmeServices
{
    public class VotoService : IVotoService
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly IFilmeRepository _filmeRepository;
        private readonly IUnityOfWork _unityOfWork;
        private readonly IVotoRepository _votoRepository;

        public VotoService(IHttpContextAccessor httpContext, 
            IFilmeRepository filmeRepository, 
            IUnityOfWork unityOfWork, 
            IVotoRepository votoRepository)
        {
            _httpContext = httpContext;
            _filmeRepository = filmeRepository;
            _unityOfWork = unityOfWork;
            _votoRepository = votoRepository;
        }

        public void VotoRating(RatingFilme ratingFilme)
        {
            var usuarioId = int.Parse(_httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var filme = _filmeRepository.GetById(ratingFilme.IdFilme);

            if (filme is null) throw new CoreException(Resources.FilmeInexistente);

            var voto = new Voto { IdFilme = filme.Id, IdUsuario = usuarioId, Rating = ratingFilme.Rating };

            _votoRepository.CriaVoto(voto);

            _unityOfWork.Commit();

            AtualizaRatingFilme(filme);
        }

        private async Task AtualizaRatingFilme(Filme filme)
        {
            filme.NuVotos += 1;

            filme.Rating = _votoRepository.GetRating(filme.NuVotos);

            _filmeRepository.Update(filme);

            _unityOfWork.Commit();
        }
    }
}
