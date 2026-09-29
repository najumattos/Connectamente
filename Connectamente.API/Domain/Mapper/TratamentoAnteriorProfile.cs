using AutoMapper;
using Connectamente.API.DTOs.TratamentoAnteriorDto;
using Connectamente.API.Models;

namespace Connectamente.API.Domain.Mapper;

public class TratamentoAnteriorProfile : Profile
{
    public TratamentoAnteriorProfile()
    {
        // =================================================================
        // 1. FLUXO DE ADIÇÃO (Criação)
        // =================================================================

        // DTO -> MODEL (Entrada/POST)
        CreateMap<TratamentoAnteriorAdicionarDto, TratamentoAnteriorModel>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Prontuario, opt => opt.Ignore());

        // MODEL -> DTO (Leitura/Fallback)
        CreateMap<TratamentoAnteriorModel, TratamentoAnteriorAdicionarDto>()
            .ForMember(dest => dest.NomePaciente, opt => opt.MapFrom(src => 
                src.Prontuario != null && src.Prontuario.Paciente != null 
                    ? src.Prontuario.Paciente.Identificacao.NomeCompleto 
                    : string.Empty));


        // =================================================================
        // 2. FLUXO DE EDIÇÃO / DETALHES
        // =================================================================

        // MODEL -> DTO (Para carregar a tela de Edição/Detalhes com dados do banco)
        CreateMap<TratamentoAnteriorModel, TratamentoAnteriorDetalhesDto>()
            // Caminho único e seguro para pegar o nome através do Prontuário
            .ForMember(dest => dest.NomePaciente, opt => opt.MapFrom(src => 
                src.Prontuario != null && src.Prontuario.Paciente != null 
                    ? src.Prontuario.Paciente.Identificacao.NomeCompleto 
                    : string.Empty));

        // DTO -> MODEL (Para processar o POST da alteração)
        CreateMap<TratamentoAnteriorDetalhesDto, TratamentoAnteriorModel>()
            .ForMember(dest => dest.Prontuario, opt => opt.Ignore())
            // Propriedades de infraestrutura/auditoria ignoradas (controladas pelo DbContext)
            .ForMember(dest => dest.DataCriacao, opt => opt.Ignore())
            .ForMember(dest => dest.DataAtualizacao, opt => opt.Ignore())
            .ForMember(dest => dest.Ativo, opt => opt.Ignore());
    }
}