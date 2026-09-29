using AutoMapper;
using Connectamente.API.DTOs.PacienteDto;
using Connectamente.API.Models;

namespace Connectamente.API.Domain.Mapper;

public class PacienteProfile : Profile
{
public PacienteProfile()
    {
          // Mapeamento de DTO para Entidade (Detalhes)
         CreateMap<PacienteModel, PacienteDetalhesDto>()
            .ForMember(dest => dest.Identificacao, opt => opt.MapFrom(src => src.Identificacao))
            .ForMember(dest => dest.Endereco, opt => opt.MapFrom(src => src.Endereco))
            .ForMember(dest => dest.NumeroProntuario, opt => opt.MapFrom(src => src.Prontuario != null ? src.Prontuario.NumeroProntuario : null))
            
  // 2. Mapeamento Familiar Principal
            .ForMember(dest => dest.ResponsavelLegal, opt => opt.MapFrom(src =>
                src.Prontuario != null 
                ? src.Prontuario.Familiares
                    .Where(f => f.ResponsavelPrincipal)
                    .Select(f => f.Identificacao != null ? f.Identificacao.NomeCompleto : null)
                    .FirstOrDefault()
                : null));                
  // Mapeamento de DTO para Entidade (Listagem)
  CreateMap<PacienteModel, PacienteListaDto>()
      .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Ativo, opt => opt.MapFrom(src => src.Ativo))
            .ForMember(dest => dest.NomeCompleto, opt => opt.MapFrom(src => src.Identificacao != null ? src.Identificacao.NomeCompleto : string.Empty))
            .ForMember(dest => dest.Telefone, opt => opt.MapFrom(src => src.Identificacao != null ? src.Identificacao.TelefonePrincipal : null))
            .ForMember(dest => dest.NumeroProntuario, opt => opt.MapFrom(src => src.Prontuario != null ? src.Prontuario.NumeroProntuario : string.Empty))
            .ForMember(dest => dest.Idade, opt => opt.MapFrom(src =>
        src.Identificacao.DataNascimento != default
            ? DateTime.Today.Year - src.Identificacao.DataNascimento.Year -
              (DateTime.Today.DayOfYear < src.Identificacao.DataNascimento.DayOfYear ? 1 : 0)
            : (int?)null))
            

            // 2. Mapeamento do Contato de Emergência (Responsável Principal)
            .ForMember(dest => dest.ResponsavelLegal, opt => opt.MapFrom(src =>
                src.Prontuario != null 
                ? src.Prontuario.Familiares
                    .Where(f => f.ResponsavelPrincipal)
                    .Select(f => f.Identificacao != null ? f.Identificacao.NomeCompleto : null)
                    .FirstOrDefault()
                : null))
            // 3. Mapeamento do Telefone do Contato de Emergência
            .ForMember(dest => dest.TelefoneRecado, opt => opt.MapFrom(src =>
                src.Prontuario != null 
                ? src.Prontuario.Familiares
                    .Where(f => f.ResponsavelPrincipal)
                    .Select(f => f.Identificacao != null ? f.Identificacao.TelefonePrincipal : null)
                    .FirstOrDefault()
                : null));



    // Mapeamento de DTO para Entidade (Cadastro)
       CreateMap<PacienteAdicionarDto, PacienteModel>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.DataAtualizacao, opt => opt.Ignore())
            .ForMember(dest => dest.Observacoes, opt => opt.Ignore())
            .ForMember(dest => dest.Prontuario, opt => opt.Ignore())
            .ForMember(dest => dest.Auditorias, opt => opt.Ignore());   

            CreateMap<PacienteEditarDto, PacienteModel>()           
             .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.DataCriacao, opt => opt.Ignore())
            .ForMember(dest => dest.DataAtualizacao, opt => opt.Ignore())
            .ForMember(dest => dest.Identificacao, opt => opt.MapFrom(src => src.Identificacao))
            .ForMember(dest => dest.Endereco, opt => opt.MapFrom(src => src.Endereco));      
    }

    
}