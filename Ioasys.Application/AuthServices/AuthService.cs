using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Ioasys.Domain.AuthAggregate.Dtos;
using Ioasys.Domain.AuthAggregate.Entities;
using Ioasys.Domain.AuthAggregate.Repositories;
using Ioasys.Domain.AuthAggregate.Services;
using Ioasys.Domain.Properties;
using Ioasys.Domain.Shared.Exceptions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using BC = BCrypt.Net.BCrypt;

namespace Ioasys.Application.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IConfiguration _configuration;

        public AuthService(IUsuarioRepository usuarioRepository, 
            IConfiguration configuration)
        {
            _usuarioRepository = usuarioRepository;
            _configuration = configuration;
        }

        public string Login(LoginDto loginDto)
        {
            var usuario = _usuarioRepository.BuscaLogin(loginDto.Login);

            if (usuario is null) throw new CoreException(Resources.LoginInvalido);

            if (!BC.Verify(loginDto.Senha, usuario.Senha)) throw new CoreException(Resources.LoginInvalido);

            var token = GenerateToken(usuario);

            return token;
        }

        public string GeneratePasswordHash(string senha)
        {
            var Hash = BC.HashPassword(senha);

            return Hash;
        }

        private string GenerateToken(Usuario usuario)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Name, usuario.Login)
            };

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Security:JWT"]));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = signingCredentials
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
