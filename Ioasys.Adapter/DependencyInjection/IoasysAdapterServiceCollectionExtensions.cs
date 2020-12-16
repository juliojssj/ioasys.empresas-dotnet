using System;
using Ioasys.Adapter.Data;
using Ioasys.Adapter.Data.Repositories;
using Ioasys.Adapter.Data.UoW;
using Ioasys.Domain.AuthAggregate.Repositories;
using Ioasys.Domain.FilmeAggregate.Repositories;
using Ioasys.Domain.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ioasys.Adapter.DependencyInjection
{
    public static class IoasysAdapterServiceCollectionExtensions
    {
        public static IServiceCollection AddAdapter(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddScoped<DataContext>();
            services.AddScoped<IUnityOfWork, UnityOfWork>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IFilmeRepository, FilmeRepository>();
            services.AddScoped<IVotoRepository, VotoRepository>();

            services.AddDbContext<DataContext>(x =>
                x.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
