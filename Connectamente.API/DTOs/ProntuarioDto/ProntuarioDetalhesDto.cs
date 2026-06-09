    using Connectamente.API.Enums;

    namespace Connectamente.API.DTOs.ProntuarioDto;

    public record ProntuarioDetalhesDto
{
    public int Id { get; init; }
    public string NumeroProntuario { get; init; } = string.Empty; 
    public SituacaoProntuarioEnum SituacaoProntuario { get; init; } 
    public DateTime? DataPrimeiraConsulta { get; init; }
    public string? ObservacoesGerais { get; init; }

    // Dados do Paciente Vinculado
    public int PacienteId { get; init; }
    public string PacienteNomeCompleto { get; init; } = string.Empty;  

    // Dados do Profissional Responsável
    public string PsicologoResponsavelId { get; init; } = string.Empty;
    public string NomePsicologoResponsavel { get; init; } = string.Empty;  
   
    public ICollection<ProntuarioTratamentoAnteriorDto> TratamentosAnteriores { get; init; } = [];
    public ICollection<ProntuarioAtendimentoDto> Atendimentos { get; init; } = [];
    public ICollection<ProntuarioDocumentoClinicoDto> DocumentosClinicos { get; init; } = [];
}

// --- SUB-DTOs AUXILIARES (Simplificados apenas para exibição em listas dentro do detalhe) ---

public record ProntuarioTratamentoAnteriorDto
{
    public int Id { get; init; }
    public TipoTratamentoAnteriorEnum TipoTratamento { get; init; } 
    public bool Internacao { get; init; }
    public string MotivoInternacao { get; set; }
}

public record ProntuarioAtendimentoDto
{
    public int Id { get; init; }
    public DateTime DataAtendimento { get; init; }
    public string Status { get; init; } = string.Empty;
}

public record ProntuarioDocumentoClinicoDto
{
    public int Id { get; init; }
    public string TipoDocumento { get; init; } = string.Empty;
    public DateTime DataCriacao { get; init; }
}