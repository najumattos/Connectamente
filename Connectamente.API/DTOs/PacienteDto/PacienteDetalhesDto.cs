namespace Connectamente.API.DTOs.PacienteDto;

public record PacienteDetalhesDto
{
    public int Id { get; init; }
    public string NomeCompleto { get; init; } = string.Empty;  
    public string? Telefone { get; init; }
    public string? TelefoneRecado { get; init; }
    public string? Sexo { get; init; }
    public string? Naturalidade { get; init; }
    public string? EstadoNascimento { get; init; }
    public string? Escolaridade { get; init; }
    public string? Profissao { get; init; }    
    public string? RG { get; init; }
    public string? CPF { get; init; }
    public string? EstadoCivil { get; init; }
    public string? Religiao { get; init; }
    public EnderecoDto? Endereco { get; init; } 
    public DateTime? DataNascimento { get; init; }
    public int? Idade { get; init; }
    
    public string? ResponsavelLegal { get; init; }
    public string? NumeroProntuario { get; init; }
    public string? PsicologoResponsavel { get; init; }

    // Propriedades de auditoria herdadas da EntityBase
    public bool Ativo { get; init; }
    public DateTime DataCriacao { get; init; }
    public DateTime? DataAtualizacao { get; init; }
}