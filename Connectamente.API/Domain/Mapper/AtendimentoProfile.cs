using AutoMapper;
using Connectamente.API.DTOs.AtendimentoDto;
using Connectamente.API.Models;

namespace Connectamente.API.Domain.Mapper;

public class AtendimentoProfile: Profile
{
    public AtendimentoProfile()
    {        
               CreateMap<AtendimentoModel, AtendimentoDetalhesDto>()
            .ForMember(dest => dest.NumeroProntuario, opt => opt.MapFrom(src => src.Prontuario != null ? src.Prontuario.NumeroProntuario : string.Empty))
            .ForMember(dest => dest.NomePaciente, opt => opt.MapFrom(src => src.Prontuario != null && src.Prontuario.Paciente != null ? src.Prontuario.Paciente.Identificacao.NomeCompleto : string.Empty))
            .ForMember(dest => dest.DocumentosClinicos, opt => opt.MapFrom(src => src.DocumentosClinicos));


      CreateMap<AtendimentoAtualizarDto, AtendimentoModel>()
            .ForMember(dest => dest.Observacoes, opt => opt.MapFrom(src => src.DadosAuditaveis != null ? src.DadosAuditaveis.Observacoes : null))
            .ForMember(dest => dest.Ativo, opt => opt.MapFrom(src => src.DadosAuditaveis != null ? src.DadosAuditaveis.Ativo : true))    
            .ForMember(dest => dest.DataCriacao, opt => opt.Ignore())
            .ForMember(dest => dest.DataAtualizacao, opt => opt.Ignore())
            .ForMember(dest => dest.ProntuarioId, opt => opt.Ignore())
            .ForMember(dest => dest.Prontuario, opt => opt.Ignore())
            .ForMember(dest => dest.DocumentosClinicos, opt => opt.Ignore());

  CreateMap<AtendimentoModel, AtendimentoListaDto>()
    .ForMember(dest => dest.NumeroProntuario, opt => opt.MapFrom(src => src.Prontuario != null ? src.Prontuario.NumeroProntuario : string.Empty))
            .ForMember(dest => dest.NomePaciente, opt => opt.MapFrom(src => src.Prontuario != null && src.Prontuario.Paciente != null ? src.Prontuario.Paciente.Identificacao.NomeCompleto : string.Empty))
            .ForMember(dest => dest.PsicologoResponsavel, opt => opt.MapFrom(src => src.Prontuario != null && src.Prontuario.PsicologoResponsavel != null ? src.Prontuario.PsicologoResponsavel.NomeCompleto : string.Empty));

        CreateMap<AtendimentoAdicionarDto, AtendimentoModel>()
             .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Prontuario, opt => opt.Ignore())
            .ForMember(dest => dest.DocumentosClinicos, opt => opt.Ignore())
            .ForMember(dest => dest.DataHoraFim, opt => opt.Ignore())
             .ForMember(dest => dest.Observacoes, opt => opt.MapFrom(src => src.Observacoes))
            .ForMember(dest => dest.Ativo, opt => opt.MapFrom(src => true))
            .ForMember(dest => dest.DataAtualizacao, opt => opt.Ignore());
    }
}