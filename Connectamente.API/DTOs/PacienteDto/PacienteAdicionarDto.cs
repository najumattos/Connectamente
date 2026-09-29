
using System.ComponentModel.DataAnnotations;

namespace Connectamente.API.DTOs.PacienteDto;

public class PacienteAdicionarDto{
    public IdentificacaoDto? Identificacao { get; set; } 
    public EnderecoDto? Endereco { get; set; } 

    [Display(Name = "Data de Cadastro")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
    public DateTime DataCriacao { get; set; }
    public bool Ativo { get; set; }
}