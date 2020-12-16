using Ioasys.Domain.FilmeAggregate.Entities;

namespace Ioasys.Domain.FilmeAggregate.Repositories
{
    public interface IVotoRepository
    {
        void CriaVoto(Voto voto);
        decimal GetRating(int NuVotos);
    }
}
