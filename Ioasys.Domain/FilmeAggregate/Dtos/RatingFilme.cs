using System.ComponentModel.DataAnnotations;

namespace Ioasys.Domain.FilmeAggregate.Dtos
{
    public class RatingFilme
    {
        public int IdFilme { get; set; }
        [Range(0, 4, ErrorMessage = "Valor deve estar entre 0 e 4")]
        public decimal Rating { get; set; }
    }
}
