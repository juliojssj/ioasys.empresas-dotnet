using System.Collections.Generic;
using Ioasys.Domain.FilmeAggregate.Dtos;

namespace Ioasys.Domain.Shared.Filters
{
    public class BuscaFilme : GenericFilter<FilmeDto>
    {
        public string Diretor { get; set; }
        public string Genero { get; set; }
        public string Nome { get; set; }
        public string Ator { get; set; }
    }
}
