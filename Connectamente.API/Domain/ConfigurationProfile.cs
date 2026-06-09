using AutoMapper;
using Connectamente.API.DTOs;
using Connectamente.API.DTOs.PacienteDto;
using Connectamente.API.DTOs.ProntuarioDto;
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
                src.Prontuario != null ? src.Prontuario.NumeroProntuario : null))

            // Resolve o Psicólogo Responsável extraindo do Prontuário ou da amarração correta do seu domínio
            .ForMember(dest => dest.PsicologoResponsavel, opt => opt.MapFrom(src =>
                src.Prontuario != null && src.Prontuario.PsicologoResponsavel != null ? src.Prontuario.PsicologoResponsavel.NomeCompleto : null));

        CreateMap<PacienteModel, PacienteListaDto>()
            .ForMember(dest => dest.ResponsavelLegal, opt => opt.MapFrom(src => 
                src.FamiliarResponsavel != null ? src.FamiliarResponsavel.NomeCompleto : null));

        // 2. Mapeamento complexo de Prontuario para Detalhes
        CreateMap<ProntuarioModel, ProntuarioDetalhesDto>()            
            .ForMember(dest => dest.PacienteNomeCompleto, 
                opt => opt.MapFrom(src => src.Paciente.NomeCompleto))        
            .ForMember(dest => dest.NomePsicologoResponsavel, 
                opt => opt.MapFrom(src => src.PsicologoResponsavel != null ? src.PsicologoResponsavel.NomeCompleto : string.Empty));        
        CreateMap<TratamentoAnteriorModel, ProntuarioTratamentoAnteriorDto>();
        CreateMap<AtendimentoModel, ProntuarioAtendimentoDto>();
        CreateMap<DocumentoClinicoModel, ProntuarioDocumentoClinicoDto>();

        CreateMap<ProntuarioModel, ProntuarioListaDto>()            
            .ForMember(dest => dest.NomeCompletoPaciente, 
                opt => opt.MapFrom(src => src.Paciente.NomeCompleto))        
            .ForMember(dest => dest.NomePsicologoResponsavel, 
                opt => opt.MapFrom(src => src.PsicologoResponsavel != null ? src.PsicologoResponsavel.NomeCompleto : string.Empty));

    }
}