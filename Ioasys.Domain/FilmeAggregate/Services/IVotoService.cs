using Ioasys.Domain.FilmeAggregate.Dtos;

namespace Ioasys.Domain.FilmeAggregate.Services
{
    public interface IVotoService
    {
        void VotoRating(RatingFilme ratingFilme);
    }
}
