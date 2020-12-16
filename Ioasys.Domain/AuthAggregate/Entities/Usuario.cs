using System.Collections.Generic;
using Ioasys.Domain.FilmeAggregate.Entities;
using Ioasys.Domain.Shared.Entities;

namespace Ioasys.Domain.AuthAggregate.Entities
{
    public class Usuario : Entity
    {
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public bool Admin { get; set; }

        public virtual ICollection<Voto> Votos { get; set; }
    }
}
