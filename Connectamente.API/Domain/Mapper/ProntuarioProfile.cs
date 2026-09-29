using AutoMapper;
using Connectamente.API.DTOs;
using Connectamente.API.DTOs.AtendimentoDto;
using Connectamente.API.DTOs.DocumentoClinicoDto;
using Connectamente.API.DTOs.FamiliarDto;
using Connectamente.API.DTOs.ProntuarioDto;
using Connectamente.API.DTOs.TratamentoAnteriorDto;
using Connectamente.API.Models;

namespace Connectamente.API.Domain.Mapper;

public class ProntuarioProfile : Profile
{
   public ProntuarioProfile()
    {
        CreateMap<ProntuarioDetalhesDto, ProntuarioPsicologoVincularDto>();
        //mapear para exibir detalhes
                CreateMap<ProntuarioModel, ProntuarioDetalhesDto>()            
 .ForMember(dest => dest.PacienteNomeCompleto, 
                opt => opt.MapFrom(src => src.Paciente.Identificacao.NomeCompleto))      
            .ForMember(dest => dest.NomePsicologoResponsavel, 
                opt => opt.MapFrom(src => src.PsicologoResponsavel != null ? src.PsicologoResponsavel.NomeCompleto : string.Empty));        
        CreateMap<TratamentoAnteriorModel, TratamentoAnteriorListaDto>();
        CreateMap<AtendimentoModel, AtendimentoListaDto>();
        CreateMap<DocumentoClinicoModel, DocumentoListaDto>();
        CreateMap<FamiliarModel, FamiliarListaDto>();               

// Este mapeamento agora vai funcionar perfeitamente porque a projeção acima entrega um IEnumerable<FamiliarModel>
CreateMap<FamiliarModel, FamiliarListaDto>();

//Mapear para Listar prontuarios
        CreateMap<ProntuarioModel, ProntuarioListaDto>()            
             .ForMember(dest => dest.NomeCompletoPaciente, 
                opt => opt.MapFrom(src => src.Paciente.Identificacao.NomeCompleto))        
            .ForMember(dest => dest.NomePsicologoResponsavel, 
                opt => opt.MapFrom(src => src.PsicologoResponsavel != null ? src.PsicologoResponsavel.NomeCompleto : string.Empty));

        // Cadastro
        CreateMap<ProntuarioAdicionarDto, ProntuarioModel>()
    .ForMember(dest => dest.Id, opt => opt.Ignore())
    .ForMember(dest => dest.DataAtualizacao, opt => opt.Ignore());
    
 CreateMap<ProntuarioEditarDto, ProntuarioModel>()
    .ForMember(dest => dest.Id, opt => opt.Ignore())
    .ForMember(dest => dest.DataCriacao, opt => opt.Ignore())
    .ForMember(dest => dest.DataAtualizacao, opt => opt.Ignore())
    .ForMember(dest => dest.NumeroProntuario, opt => opt.Ignore())
    .ForMember(dest => dest.PacienteId, opt => opt.Ignore())
    .ForMember(dest => dest.PsicologoResponsavelId, opt => opt.Ignore());
            
    }
}