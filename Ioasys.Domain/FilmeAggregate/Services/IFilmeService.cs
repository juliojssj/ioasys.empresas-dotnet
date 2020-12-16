using Ioasys.Domain.FilmeAggregate.Dtos;
using Ioasys.Domain.Shared.Filters;

namespace Ioasys.Domain.FilmeAggregate.Services
{
    public interface IFilmeService
    {
        void RegistraFilme(FilmeRegistroDto filmeRegistroDto);
        BuscaFilme BuscaFilmes(BuscaFilme busca);
        FilmeDto BuscaFilme(int idFilme);
    }
}
