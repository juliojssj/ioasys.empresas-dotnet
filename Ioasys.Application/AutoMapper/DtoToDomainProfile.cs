using System.Collections.Generic;
using AutoMapper;
using Ioasys.Domain.AuthAggregate.Dtos;
using Ioasys.Domain.AuthAggregate.Entities;
using Ioasys.Domain.FilmeAggregate.Dtos;
using Ioasys.Domain.FilmeAggregate.Entities;

namespace Ioasys.Application.AutoMapper
{
    public class DtoToDomainProfile : Profile
    {
        public DtoToDomainProfile()
        {
            CreateMap<AdminRegistroDto, Usuario>()
                .ForMember(dest => dest.Admin, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.Ativo, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Login.ToLower()));

            CreateMap<UsuarioRegistroDto, Usuario>()
                .ForMember(dest => dest.Admin, opt => opt.MapFrom(src => false))
                .ForMember(dest => dest.Ativo, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Login.ToLower()));

            CreateMap<UsuarioAtualizaDto, Usuario>();

            CreateMap<FilmeRegistroDto, Filme>()
                .ForMember(dest => dest.Ativo, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.Ators, opt => opt.MapFrom<FilmeAtorResolver>());
        }
    }

    public class FilmeAtorResolver : IValueResolver<FilmeRegistroDto, Filme, ICollection<FilmeAtor>>
    {
        public ICollection<FilmeAtor> Resolve(FilmeRegistroDto source, Filme destination, 
            ICollection<FilmeAtor> destMember, ResolutionContext context)
        {
            var list = new List<FilmeAtor>();

            foreach (var ator in source.Ators)
            {
                var filmeAtor = new FilmeAtor
                {
                    Ator = new Ator{Ativo = true, Nome = ator.Nome},
                    Filme = destination
                };
                list.Add(filmeAtor);
            }

            return list;
        }
    }
}
