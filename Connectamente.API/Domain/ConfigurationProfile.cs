using AutoMapper;
using Connectamente.API.DTOs;
using Connectamente.API.DTOs.PacienteDto;
using Connectamente.API.Models;

namespace Connectamente.API.Domain;

public class ConfigurationProfile : Profile
{
    public ConfigurationProfile()
    {
        CreateMap<Endereco, EnderecoDto>();

        // 2. Mapeamento complexo de Paciente para Detalhes
        CreateMap<PacienteModel, PacienteDetalhesDto>()
            .ForMember(dest => dest.Endereco, opt => opt.MapFrom(src => src.Endereco))
            .ForMember(dest => dest.ResponsavelLegal, opt => opt.MapFrom(src =>
                src.FamiliarResponsavel != null ? src.FamiliarResponsavel.NomeCompleto : null))
            .ForMember(dest => dest.NumeroProntuario, opt => opt.MapFrom(src =>
                src.Prontuario != null ? src.Prontuario.NumeroProntuario : null));

            /* Resolve o Psicólogo Responsável extraindo do Prontuário ou da amarração correta do seu domínio
            .ForMember(dest => dest.PsicologoResponsavel, opt => opt.MapFrom(src =>
                src.Prontuario != null && src.Prontuario.Psicologo != null ? src.Prontuario.Psicologo.NomeCompleto : null));*/

        CreateMap<PacienteModel, PacienteListaDto>()
            .ForMember(dest => dest.ResponsavelLegal, opt => opt.MapFrom(src => 
                src.FamiliarResponsavel != null ? src.FamiliarResponsavel.NomeCompleto : null));

    }
}