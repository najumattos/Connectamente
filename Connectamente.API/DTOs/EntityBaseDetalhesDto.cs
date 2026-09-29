using System.ComponentModel.DataAnnotations;

namespace Connectamente.API.DTOs;

public class EntityBaseDetalhesDto
{
[Display(Name = "Data de Cadastro")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
    public DateTime DataCriacao { get; set; }

    [Display(Name = "Última Atualização")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
    public DateTime? DataAtualizacao { get; set; }

    [Display(Name = "Observações Gerais")]
    [DataType(DataType.MultilineText)]
    public string? Observacoes { get; set; }
     [Display(Name = "Status do Cadastro")]
    public bool Ativo { get; set; }
}