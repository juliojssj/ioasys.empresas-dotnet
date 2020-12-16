using Ioasys.Domain.AuthAggregate.Dtos;
using Ioasys.Domain.Shared.Filters;

namespace Ioasys.Domain.AuthAggregate.Services
{
    public interface IUsuarioService
    {
        void RegistraAdmin(AdminRegistroDto adminRegistroDto);
        void RegistraUsuario(UsuarioRegistroDto usuarioRegistroDto);
        void AtualizaUsuario(UsuarioAtualizaDto usuarioAtualizaDto);
        void DesativaUsuario(int idUsuario);
        void DesativaUsuario();
        GenericFilter<UsuarioListaDto> BuscaUsuario(GenericFilter<UsuarioListaDto> busca);
    }
}
