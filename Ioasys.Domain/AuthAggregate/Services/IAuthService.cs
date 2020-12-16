using Ioasys.Domain.AuthAggregate.Dtos;

namespace Ioasys.Domain.AuthAggregate.Services
{
    public interface IAuthService
    {
        string Login(LoginDto loginDto);
        string GeneratePasswordHash(string senha);
    }
}
