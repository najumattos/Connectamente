using Connectamente.API.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Connectamente.API.Models;

[Table("ProntuarioAdulto")]
public class ProntuarioAdultoModel
{
    [Key] public string ProntuarioId { get; set; }

    public string PsicologoResponsavelId { get; set; }
    [ForeignKey("PsicologoResponsavelId")]
    [Required(ErrorMessage = "O psicologo é obrigatório.")]
    public virtual PsicologoModel PsicologoResponsavel { get; set; }


    public string PacienteId { get; set; }
    [ForeignKey("PacienteId")]
    [Required(ErrorMessage = "O paciente é obrigatório.")]
    public virtual PacienteModel Paciente { get; set; }

    [Required]
    [Display(Name = "Data de Criação")]
    public DateTime DataCriacao { get; set; } = DateTime.Now;

    [Required]
    [Display(Name = "Última Atualização")]
    public DateTime DataUltimaAtualizacao { get; set; } = DateTime.Now;
    public string QueixaPrincipal { get; set; }   
    public string QueixaSecundaria { get; set; }
    public string Sintomas { get; set; }
    public string HistoricoDoencaAtual { get; set; }
    public string Medicamentos { get; set; }
    public string HistoricoInfancia { get; set; }
    public string Rotina { get; set; }
    public string Vicios { get; set; }
    public string Hobbies { get; set; }
    public string Trabalho { get; set; }
    public string HistoricoFamiliar { get; set; }
    public string Aparencia { get; set; } //condições físicas e o autocuidado do paciente
    public string Comportamento { get; set; }
    public string Orientacao { get; set; } // Auto-identificatória, corporal, etc.
    public string Memoria { get; set; }
    public string Sensopercepcao { get; set; }
    public string PensamentoConteudo { get; set; }// Obsessões, delírios, etc.
    public string Humor { get; set; }
  //  public AtitudeEntrevistadorEnum Atitude { get; set; }
 //   public ConscienciaDoencaEnum Consciencia { get; set; }
    public string HipoteseDiagnostica { get; set; }
    public string Nacionalidade { get; set; }
  //  public EstadoCivilEnum EstadoCivil { get; set; }
  //  public GrauInstrucaoEnum GrauInstrucao { get; set; }
    public string Profissao { get; set; }
    //public string Residencia { get; set; } tabela endereco
    public TipoProntuarioEnum TipoProntuario { get; set; }
    public IEnumerable<ConsultaModel> ConsultasVinculadas { get; set; }
}

