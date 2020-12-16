using Ioasys.Domain.FilmeAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ioasys.Adapter.Data.Mappings
{
    public class FilmeMap : IEntityTypeConfiguration<Filme>
    {
        public void Configure(EntityTypeBuilder<Filme> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(x => x.Nome).IsRequired();

            builder.Property(x => x.Diretor).IsRequired();

            builder.Property(x => x.Genero).IsRequired();

            builder.Property(x => x.Rating).HasDefaultValue(0).IsRequired();

            builder.Property(x => x.NuVotos).HasDefaultValue(0).IsRequired();

            builder.HasMany(x => x.Ators)
                .WithOne(x => x.Filme)
                .HasForeignKey(x => x.IdFilme);
        }
    }
}
