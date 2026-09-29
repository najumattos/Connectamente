using AutoMapper;
using Connectamente.API.DTOs.DocumentoClinicoDto;
using Connectamente.API.Models;

namespace Connectamente.API.Domain.Mapper;

public class DocumentoProfile : Profile
{
    public DocumentoProfile()
    {
        CreateMap<DocumentoClinicoModel, DocumentoDetalhesDto>().ForMember(dest => dest.NomePsicologoResponsavel, opt => opt.MapFrom(src => src.Prontuario != null && src.Prontuario.PsicologoResponsavel != null ? src.Prontuario.PsicologoResponsavel.NomeCompleto : string.Empty));
       CreateMap<DocumentoClinicoModel, DocumentoListaDto>().ReverseMap();

        // Mapeamento de ENTRADA: DTO -> Banco (Para a Action de Salvar)
        CreateMap<DocumentoAdicionarDto, DocumentoClinicoModel>()
        .ForMember(dest => dest.Observacoes, opt => opt.MapFrom(src => src.DadosAuditaveis != null ? src.DadosAuditaveis.Observacoes : null))
    .ForMember(dest => dest.UsuarioResponsavelId, opt => opt.MapFrom(src => src.UsuarioResponsavelId))
    .ForMember(dest => dest.Usuario, opt => opt.Ignore()) 
    .ForMember(dest => dest.Id, opt => opt.Ignore())
    .ForMember(dest => dest.Atendimento, opt => opt.Ignore())
    .ForMember(dest => dest.Usuario, opt => opt.Ignore());

        // Mapeamento de SAÍDA: Banco -> DTO
        CreateMap<DocumentoClinicoModel, DocumentoAdicionarDto>()
            .ForMember(dest => dest.DadosAuditaveis, opt => opt.MapFrom(src => src));
    }
}