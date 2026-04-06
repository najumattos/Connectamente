using Connectamente.API.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Connectamente.API.Models;

[Table("Paciente")]
public class PacienteModel
{
    [Key] public string PacienteId { get; set; }

    [Required]public string UsuarioId { get; set; }
    [ForeignKey("UsuarioId")]
    public virtual UsuarioModel Usuario { get; set; }

    [Required] public string ContatoEmergencia { get; set; }

    [Display(Name = "Histórico do Paciente", Prompt = "Informações como se ja faz acompanhamento, uso de medicacao, diagnosticos previos, sono, alimentacao, uso de substancias, atividade fisica"),
    StringLength(1000), Required(ErrorMessage = "Campo obrigatório")]
    public string HistoricoPaciente { get; set; }

    public string PsicologoResponsavelId { get; set; }
    [ForeignKey("PsicologoResponsavelId")]
    [Required(ErrorMessage = "O psicologo é obrigatório.")]
    public virtual PsicologoModel PsicologoResponsavel { get; set; }

}

/* Modelo gerado por Ia de acordo com modelo do formulario da GRAN
 public int Id { get; set; }
    public string NumeroProntuario { get; set; }
    public DateTime DataPrimeiraConsulta { get; set; }

    // Identificação do Paciente
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Sexo { get; set; }
    public int Idade { get; set; }
    public string Profissao { get; set; }
    public string Naturalidade { get; set; }
    public string EstadoNaturalidade { get; set; }
    public string Escolaridade { get; set; }
    public string RG { get; set; }
    public string CPF { get; set; }
    public string EstadoCivil { get; set; }
    public string Religiao { get; set; }

    // Endereço
    public string Endereco { get; set; }
    public string NumeroEndereco { get; set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string CEP { get; set; }

    // Contato
    public string Telefone { get; set; }
    public string TelefoneRecado { get; set; }

    // Filiação
    public string NomePai { get; set; }
    public string NomeMae { get; set; }
    public string NomeResponsavel { get; set; }
    public string GrauParentescoResponsavel { get; set; }

    // Tratamentos Anteriores (Booleanos para Sim/Não)
    public bool TeveTratamentoPsicologico { get; set; }
    public bool TeveTratamentoNeurologico { get; set; }
    public bool TeveTratamentoPsiquiatrico { get; set; }
    public bool TeveTratamentoCardiologico { get; set; }
    public bool TeveInternacao { get; set; }
    public string MotivoInternacao { get; set; }
    public string OutrosTratamentos { get; set; }
 
 */