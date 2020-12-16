using System.Collections.Generic;

namespace Ioasys.Domain.FilmeAggregate.Dtos
{
    public class FilmeRegistroDto
    {
        public string Nome { get; set; }
        public string Diretor { get; set; }
        public string Genero { get; set; }

        public List<AtorDto> Ators { get; set; }
    }
}
