using Ioasys.Domain.FilmeAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ioasys.Adapter.Data.Mappings
{
    public class FilmeAtorMap : IEntityTypeConfiguration<FilmeAtor>
    {
        public void Configure(EntityTypeBuilder<FilmeAtor> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(x => x.IdAtor).IsRequired();

            builder.Property(x => x.IdFilme).IsRequired();
        }
    }
}
