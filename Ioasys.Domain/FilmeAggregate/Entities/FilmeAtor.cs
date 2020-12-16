namespace Ioasys.Domain.FilmeAggregate.Entities
{
    public class FilmeAtor
    {
        public int Id { get; set; }
        public int IdFilme { get; set; }
        public int IdAtor { get; set; }

        public virtual Filme Filme { get; set; }
        public virtual Ator Ator { get; set; }
    }
}
