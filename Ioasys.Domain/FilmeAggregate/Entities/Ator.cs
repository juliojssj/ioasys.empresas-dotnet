using System.Collections.Generic;
using Ioasys.Domain.Shared.Entities;

namespace Ioasys.Domain.FilmeAggregate.Entities
{
    public class Ator : Entity
    {
        public string Nome { get; set; }

        public virtual ICollection<FilmeAtor> Filmes { get; set; }
    }
}
