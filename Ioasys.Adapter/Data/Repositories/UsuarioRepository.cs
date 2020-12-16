using System.Linq;
using Ioasys.Domain.AuthAggregate.Dtos;
using Ioasys.Domain.AuthAggregate.Entities;
using Ioasys.Domain.AuthAggregate.Repositories;
using Ioasys.Domain.Shared.Filters;

namespace Ioasys.Adapter.Data.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(DataContext dbContext) : base(dbContext)
        {
        }

        public Usuario BuscaLogin(string login)
        {
           var usuario = DbContext.Set<Usuario>().FirstOrDefault(x => x.Login == login);

           return usuario;
        }

        public GenericFilter<UsuarioListaDto> BuscaUsuario(GenericFilter<UsuarioListaDto> busca)
        {
            var query = DbContext.Set<Usuario>().Where(x => !x.Admin && x.Ativo);

            if (busca.ItemsPerPage != 0 && busca.Page != 0)
            {
                query = query.Skip((busca.Page - 1) * busca.ItemsPerPage).Take(busca.ItemsPerPage);
            }

            query = query.OrderBy(x => x.Nome);

            busca.Items = query.Select(x => new UsuarioListaDto
            {
                Nome = x.Nome,
                Login = x.Login
            }).ToList();

            return busca;
        }
    }
}
