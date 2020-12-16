using System;
using Ioasys.Application.AuthServices;
using Ioasys.Application.FilmeServices;
using Ioasys.Domain.AuthAggregate.Services;
using Ioasys.Domain.FilmeAggregate.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Ioasys.Application.DependencyInjection
{
    public static class IoasysAdapterServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IFilmeService, FilmeService>();
            services.AddScoped<IVotoService, VotoService>();

            return services;
        }
    }
}
