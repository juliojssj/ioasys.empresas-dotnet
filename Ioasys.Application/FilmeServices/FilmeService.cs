using System.Security.Claims;
using AutoMapper;
using Ioasys.Domain.AuthAggregate.Repositories;
using Ioasys.Domain.FilmeAggregate.Dtos;
using Ioasys.Domain.FilmeAggregate.Entities;
using Ioasys.Domain.FilmeAggregate.Repositories;
using Ioasys.Domain.FilmeAggregate.Services;
using Ioasys.Domain.Properties;
using Ioasys.Domain.Shared.Exceptions;
using Ioasys.Domain.Shared.Filters;
using Ioasys.Domain.Shared.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Ioasys.Application.FilmeServices
{
    public class FilmeService : IFilmeService
    {
        private readonly IMapper _mapper;
        private readonly IFilmeRepository _filmeRepository;
        private readonly IUnityOfWork _unityOfWork;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IUsuarioRepository _usuarioRepository;

        public FilmeService(IMapper mapper, 
            IFilmeRepository filmeRepository, 
            IUnityOfWork unityOfWork, 
            IHttpContextAccessor httpContext, IUsuarioRepository usuarioRepository)
        {
            _mapper = mapper;
            _filmeRepository = filmeRepository;
            _unityOfWork = unityOfWork;
            _httpContext = httpContext;
            _usuarioRepository = usuarioRepository;
        }

        public void RegistraFilme(FilmeRegistroDto filmeRegistroDto)
        {
            var userId = int.Parse(_httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var user = _usuarioRepository.GetById(userId);

            if (!user.Admin) throw new CoreException(Resources.RegistrarFilmeSemPermissao);

            var filme = _mapper.Map<Filme>(filmeRegistroDto);

            _filmeRepository.Create(filme);

            _unityOfWork.Commit();
        }

        public BuscaFilme BuscaFilmes(BuscaFilme busca)
        {
            var result = _filmeRepository.BuscaFilmes(busca);

            return result;
        }

        public FilmeDto BuscaFilme(int idFilme)
        {
            var result = _filmeRepository.BuscaFilme(idFilme);

            return result;
        }
    }
}
