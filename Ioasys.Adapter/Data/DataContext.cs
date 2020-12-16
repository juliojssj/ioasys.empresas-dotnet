using Ioasys.Adapter.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Ioasys.Adapter.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new FilmeMap());
            modelBuilder.ApplyConfiguration(new AtorMap());
            modelBuilder.ApplyConfiguration(new FilmeAtorMap());
        }
    }
}
