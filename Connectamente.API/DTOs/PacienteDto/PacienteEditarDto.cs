namespace Connectamente.API.DTOs.PacienteDto;

public class PacienteEditarDto{
    public IdentificacaoDto? Identificacao { get; set; } 
    public EnderecoDto? Endereco { get; set; }    
    public bool Ativo { get; set; }
    public string Observacoes { get; set; }
}