using System.Linq;
using Ioasys.Domain.FilmeAggregate.Dtos;
using Ioasys.Domain.FilmeAggregate.Entities;
using Ioasys.Domain.FilmeAggregate.Repositories;
using Ioasys.Domain.Shared.Filters;
using Microsoft.EntityFrameworkCore;

namespace Ioasys.Adapter.Data.Repositories
{
    public class FilmeRepository : Repository<Filme>, IFilmeRepository
    {
        public FilmeRepository(DataContext dbContext) : base(dbContext)
        {
        }

        public BuscaFilme BuscaFilmes(BuscaFilme busca)
        {
            var query = DbContext.Set<Filme>()
                .Include(x => x.Ators)
                    .ThenInclude(x => x.Ator)
                .Where(x => x.Ativo);

            if (!string.IsNullOrEmpty(busca.Nome))
            {
                query = query.Where(x => x.Nome.ToLower().Contains(busca.Nome.ToLower()));
            }

            if (!string.IsNullOrEmpty(busca.Genero))
            {
                query = query.Where(x => x.Genero.ToLower().Contains(busca.Genero.ToLower()));
            }

            if (!string.IsNullOrEmpty(busca.Diretor))
            {
                query = query.Where(x => x.Diretor.ToLower().Contains(busca.Diretor.ToLower()));
            }

            if (!string.IsNullOrEmpty(busca.Ator))
            {
                query = query.Where(x => x.Ators.Any(y => y.Ator.Nome.ToLower().Contains(busca.Ator.ToLower())));
            }

            if (busca.ItemsPerPage != 0 && busca.Page != 0)
            {
                query = query.Skip((busca.Page - 1) * busca.ItemsPerPage).Take(busca.ItemsPerPage);
            }

            query = query.OrderBy(x => x.Rating).ThenBy(x => x.Nome);

            var result = query.Select(x => new FilmeDto
            {
                Diretor = x.Diretor,
                Genero = x.Genero,
                Nome = x.Nome,
                Rating = x.Rating,
                Ator = x.Ators.Select(y => new AtorDto
                {
                    Nome = y.Ator.Nome
                }).ToList()
            });

            busca.Items = result.ToList();

            return busca;
        }

        public FilmeDto BuscaFilme(int idFilme)
        {
            var filme = DbContext.Set<Filme>()
                .Include(x => x.Ators)
                    .ThenInclude(x => x.Ator)
                .FirstOrDefault(x => x.Id == idFilme);

            if (filme is null) return null;

            var filmeGet = new FilmeDto
            {
                Diretor = filme.Diretor,
                Nome = filme.Nome,
                Genero = filme.Genero,
                Rating = filme.Rating,
                Ator = filme.Ators.Select(x => new AtorDto
                {
                    Nome = x.Ator.Nome
                }).ToList()
            };

            return filmeGet;
        }
    }
}
