using Ioasys.Domain.FilmeAggregate.Dtos;
using Ioasys.Domain.FilmeAggregate.Entities;
using Ioasys.Domain.Shared.Filters;
using Ioasys.Domain.Shared.Interfaces;

namespace Ioasys.Domain.FilmeAggregate.Repositories
{
    public interface IFilmeRepository : IRepository<Filme>
    {
        BuscaFilme BuscaFilmes(BuscaFilme busca);
        FilmeDto BuscaFilme(int idFilme);
    }
}
