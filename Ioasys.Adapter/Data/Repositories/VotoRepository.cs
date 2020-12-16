using System.Linq;
using Ioasys.Domain.FilmeAggregate.Entities;
using Ioasys.Domain.FilmeAggregate.Repositories;

namespace Ioasys.Adapter.Data.Repositories
{
    public class VotoRepository : IVotoRepository
    {
        private readonly DataContext _dbContext;

        public VotoRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CriaVoto(Voto voto)
        {
            _dbContext.Set<Voto>().Add(voto);
        }

        public decimal GetRating(int votos)
        {
            var ratings = _dbContext.Set<Voto>().Select(x => x.Rating).ToList();

            return ratings.Sum() / votos;
        }
    }
}
