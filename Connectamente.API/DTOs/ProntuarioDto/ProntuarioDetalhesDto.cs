using System.ComponentModel.DataAnnotations;
using Connectamente.API.DTOs.AtendimentoDto;
using Connectamente.API.DTOs.DocumentoClinicoDto;
using Connectamente.API.DTOs.FamiliarDto;
using Connectamente.API.DTOs.TratamentoAnteriorDto;
using Connectamente.API.Enums;

namespace Connectamente.API.DTOs.ProntuarioDto;

    public class ProntuarioDetalhesDto : EntityBaseDetalhesDto
{
   [Required]
    public int Id { get; set; }

    [Display(Name = "Número do Prontuário")]
    public string NumeroProntuario { get; set; } = string.Empty; 

    [Display(Name = "Situação do Prontuário")]
    public SituacaoEnum SituacaoProntuario { get; set; } 
    // Dados do Paciente Vinculado
    [Required]
    public int PacienteId { get; set; }

    [Display(Name = "Paciente")]
    public string PacienteNomeCompleto { get; set; } = string.Empty;  

    // Dados do Profissional Responsável
    [Required]
    public string PsicologoResponsavelId { get; set; } = string.Empty;

    [Display(Name = "Psicólogo Responsável")]
    public string NomePsicologoResponsavel { get; set; } = string.Empty;  
   
    // Coleções convertidas para ViewModels de exibição
    public ICollection<TratamentoAnteriorListaDto> TratamentosAnteriores { get; set; } = [];
    public ICollection<AtendimentoListaDto> Atendimentos { get; set; } = [];
    public ICollection<DocumentoListaDto> DocumentosClinicos { get; set; } = [];
    public ICollection<FamiliarListaDto> Familiares { get; set; } =[];
}