using Ioasys.Domain.AuthAggregate.Dtos;
using Ioasys.Domain.AuthAggregate.Entities;
using Ioasys.Domain.Shared.Filters;
using Ioasys.Domain.Shared.Interfaces;

namespace Ioasys.Domain.AuthAggregate.Repositories
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Usuario BuscaLogin(string login);
        GenericFilter<UsuarioListaDto> BuscaUsuario(GenericFilter<UsuarioListaDto> busca);
    }
}
