using Ioasys.Domain.FilmeAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ioasys.Adapter.Data.Mappings
{
    public class AtorMap : IEntityTypeConfiguration<Ator>
    {
        public void Configure(EntityTypeBuilder<Ator> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(x => x.Nome).IsRequired();

            builder.HasMany(x => x.Filmes)
                .WithOne(x => x.Ator)
                .HasForeignKey(x => x.IdAtor);
        }
    }
}
