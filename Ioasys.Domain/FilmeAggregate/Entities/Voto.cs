using Ioasys.Domain.AuthAggregate.Entities;

namespace Ioasys.Domain.FilmeAggregate.Entities
{
    public class Voto
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdFilme { get; set; }
        public decimal Rating { get; set; }

        public virtual Filme Filme { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
