﻿using AutoMapper;
using Ioasys.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Ioasys.Api.Configs
{
    public static class AutoMapperConfiguration
    {
        public static void RegisterMappings(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new DtoToDomainProfile());
            });

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
