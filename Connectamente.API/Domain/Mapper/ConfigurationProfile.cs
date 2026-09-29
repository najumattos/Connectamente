using AutoMapper;
using Connectamente.API.DTOs;
using Connectamente.API.DTOs.AuthDto;
using Connectamente.API.Models;

namespace Connectamente.API.Domain.Mapper;

public class ConfigurationProfile : Profile
{
    public ConfigurationProfile()
    {
        CreateMap<ApplicationUserModel, LoginDto>().ReverseMap();
        CreateMap<ApplicationUserModel, AuthUserDto>().ReverseMap();
        CreateMap<Endereco, EnderecoDto>().ReverseMap();
        CreateMap<EntityBase, EntityBaseDetalhesDto>().ReverseMap();     
        CreateMap<IdentificacaoDto, Identificacao>();  
        CreateMap<Identificacao, IdentificacaoDto>()
    .ForMember(dest => dest.Idade, opt => opt.MapFrom(src =>
        src.DataNascimento != default
            ? DateTime.Today.Year - src.DataNascimento.Year -
              (DateTime.Today.DayOfYear < src.DataNascimento.DayOfYear ? 1 : 0)
            : (int?)null))
    .ForMember(dest => dest.DataNascimento, opt => opt.MapFrom(src => src.DataNascimento));
    ;
    }
}