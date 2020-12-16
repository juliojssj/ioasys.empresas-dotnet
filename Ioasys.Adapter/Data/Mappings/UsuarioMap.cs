using Ioasys.Domain.AuthAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ioasys.Adapter.Data.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(x => x.Nome).HasMaxLength(150).IsRequired();

            builder.Property(x => x.Login).HasMaxLength(50).IsRequired();

            builder.Property(x => x.Senha).IsRequired();

            builder.Property(x => x.Admin).IsRequired();
        }
    }
}
