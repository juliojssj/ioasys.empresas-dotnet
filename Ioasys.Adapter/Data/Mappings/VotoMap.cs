using Ioasys.Domain.FilmeAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ioasys.Adapter.Data.Mappings
{
    public class VoteMap : IEntityTypeConfiguration<Voto>
    {
        public void Configure(EntityTypeBuilder<Voto> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(x => x.IdUsuario).IsRequired();

            builder.Property(x => x.IdFilme).IsRequired();

            builder.HasOne(x => x.Filme)
                .WithMany(x => x.Votos)
                .HasForeignKey(x => x.IdFilme);

            builder.HasOne(x => x.Usuario)
                .WithMany(x => x.Votos)
                .HasForeignKey(x => x.IdUsuario);
        }
    }
}
