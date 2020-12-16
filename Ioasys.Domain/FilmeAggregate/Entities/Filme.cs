using System.Collections.Generic;
using Ioasys.Domain.Shared.Entities;

namespace Ioasys.Domain.FilmeAggregate.Entities
{
    public class Filme : Entity
    {
        public string Nome { get; set; }
        public string Diretor { get; set; }
        public string Genero { get; set; }
        public decimal Rating { get; set; }
        public int NuVotos { get; set; }

        public virtual ICollection<FilmeAtor> Ators { get; set; }
        public virtual ICollection<Voto> Votos { get; set; }
    }
}
