using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestFast.Api.Model;
using TestFast.Application.Clientes.Dtos;
using TestFast.Data.Data.Models;

namespace TestFast.Api.Mappings
{
    public class ClienteMapping : Profile
    {
        public ClienteMapping()
        {
            CreateMap<ClienteModel, ClienteDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Document, opt => opt.MapFrom(src => src.Documento));
            CreateMap<ClienteDto, ClienteModel>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Documento, opt => opt.MapFrom(src => src.Document));

            CreateMap<ClienteDto, ClientEntity>();
            CreateMap<ClientEntity, ClienteDto>();
        }
    }
}
