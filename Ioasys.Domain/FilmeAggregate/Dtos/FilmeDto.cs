using System.Collections.Generic;

namespace Ioasys.Domain.FilmeAggregate.Dtos
{
    public class FilmeDto
    {
        public string Nome { get; set; }
        public string Diretor { get; set; }
        public string Genero { get; set; }
        public decimal Rating { get; set; }

        public List<AtorDto> Ator { get; set; }
    }
}
