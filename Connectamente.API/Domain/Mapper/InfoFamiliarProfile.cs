using AutoMapper;
using Connectamente.API.DTOs.FamiliarDto;
using Connectamente.API.Models;

namespace Connectamente.API.Domain.Mapper;

public class InfoFamiliarProfile : Profile
{
    public InfoFamiliarProfile()
    {
        CreateMap<FamiliarAdicionarDto, FamiliarModel>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Prontuario, opt => opt.Ignore())
           // .ForMember(dest => dest.EnderecoId, opt => opt.Ignore())
            .ReverseMap();

            CreateMap<FamiliarDetalhesDto, FamiliarModel>().ReverseMap();
           
            CreateMap<FamiliarListaDto, FamiliarModel>();
    }
}