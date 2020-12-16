using System.Security.Claims;
using AutoMapper;
using Ioasys.Domain.AuthAggregate.Dtos;
using Ioasys.Domain.AuthAggregate.Entities;
using Ioasys.Domain.AuthAggregate.Repositories;
using Ioasys.Domain.AuthAggregate.Services;
using Ioasys.Domain.Properties;
using Ioasys.Domain.Shared.Exceptions;
using Ioasys.Domain.Shared.Filters;
using Ioasys.Domain.Shared.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Ioasys.Application.AuthServices
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUnityOfWork _unityOfWork;
        private readonly IAuthService _authService;
        private readonly IHttpContextAccessor _httpContext;

        public UsuarioService(IMapper mapper, 
            IUsuarioRepository usuarioRepository, 
            IUnityOfWork unityOfWork, 
            IAuthService authService, 
            IHttpContextAccessor httpContext)
        {
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
            _unityOfWork = unityOfWork;
            _authService = authService;
            _httpContext = httpContext;
        }

        public void RegistraAdmin(AdminRegistroDto adminRegistroDto)
        {
            var admin = _mapper.Map<Usuario>(adminRegistroDto);

            admin.Senha = _authService.GeneratePasswordHash(adminRegistroDto.Senha);

            _usuarioRepository.Create(admin);

            _unityOfWork.Commit();
        }

        public void RegistraUsuario(UsuarioRegistroDto usuarioRegistroDto)
        {
            var admin = _mapper.Map<Usuario>(usuarioRegistroDto);

            admin.Senha = _authService.GeneratePasswordHash(usuarioRegistroDto.Senha);

            _usuarioRepository.Create(admin);

            _unityOfWork.Commit();
        }

        public void AtualizaUsuario(UsuarioAtualizaDto usuarioAtualizaDto)
        {
            var usuarioId = int.Parse(_httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

            if (usuarioId != usuarioAtualizaDto.Id) throw new CoreException(Resources.EditarSemPermissao);

            var usuario = _usuarioRepository.GetById(usuarioId);

            usuario.Nome = usuarioAtualizaDto.Nome;

            _usuarioRepository.Update(usuario);

            _unityOfWork.Commit();
        }

        public void DesativaUsuario(int idUsuario)
        {
            var idToken = int.Parse(_httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var usuarioPermissao = _usuarioRepository.GetById(idToken);

            if (!usuarioPermissao.Admin) throw new CoreException(Resources.InativarSemPermissao);

            var usuarioDesativa = new Usuario {Id = idUsuario, Ativo = false};

            _usuarioRepository.Inactivate(usuarioDesativa);

            _unityOfWork.Commit();
        }

        public void DesativaUsuario()
        {
            var idToken = int.Parse(_httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var usuarioDesativa = new Usuario { Id = idToken, Ativo = false };

            _usuarioRepository.Inactivate(usuarioDesativa);

            _unityOfWork.Commit();
        }

        public GenericFilter<UsuarioListaDto> BuscaUsuario(GenericFilter<UsuarioListaDto> busca)
        {
            var result = _usuarioRepository.BuscaUsuario(busca);

            return result;
        }
    }
}
