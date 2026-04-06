using AutoMapper;
using Connectamente.API.Models;
using Connectamente.API.Models.ViewModel;
using Connectamente.API.Usuario;

namespace Connectamente.API.Domain;

public class ConfigurationProfile : Profile
{
    public ConfigurationProfile()
    {
        //verificar isso aquiiiiidadnsadbab
        // Mapeamento nos dois sentidos (Entidade <-> DTO)
        CreateMap<PsicologoDto, PsicologoDto>().ReverseMap();
        CreateMap<PacienteDto, PacienteDto>().ReverseMap();

    }
}