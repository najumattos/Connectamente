using AutoMapper;
using Connectamente.API.DTOs.PsicologoDto;
using Connectamente.API.Models;

namespace Connectamente.API.Domain.Mapper;

public class PsicologoProfile : Profile
{
public PsicologoProfile()
    {
        CreateMap<ApplicationUserModel, PsicologoDetalhesDto>()
            .ForMember(dest => dest.Telefone, opt => opt.MapFrom(src => src.PhoneNumber));
            
        CreateMap<ApplicationUserModel, PsicologoListaDto>()
        .ForMember(dest => dest.PsicologoResponsavelId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Telefone, opt => opt.MapFrom(src => src.PhoneNumber));           
    }
}