using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Connectamente.API.Models
{
    [Table("ProntuarioAdolescente")]
    public class ProntuarioAdolescenteModel
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
        public bool FoiDesejado { get; set; }
        public DesenvolvimentoAdolescente Desenvolvimento { get; set; } = new();
        public AntecedentesFamiliares Antecedentes { get; set; } = new();
        public AmbienteSocial Ambiente { get; set; } = new();
        public string Escola { get; set; } = string.Empty;
        public DadosResponsavel Pai { get; set; } = new();
        public DadosResponsavel Mae { get; set; } = new();
        public string CondicaoConjugalPais { get; set; }
    }
}
/*
 using System.ComponentModel.DataAnnotations;

namespace ClinicaEscola.Models;

public class AnamneseAdolescente
{
    [cite_start]// I - DADOS DE IDENTIFICAÇÃO [cite: 156]
    public IdentificacaoAdolescente Identificacao { get; set; } = new();

    [cite_start]// II - QUEIXA OU MOTIVO DA CONSULTA [cite: 172]
    public MotivoConsulta Queixa { get; set; } = new();

    [cite_start]// III - CONCEPÇÃO [cite: 182]
    public bool FoiDesejado { get; set; } [cite: 183]

    [cite_start]// IV - DESENVOLVIMENTO [cite: 184]
    public DesenvolvimentoAdolescente Desenvolvimento { get; set; } = new();

    [cite_start]// V - ANTECEDENTES FAMILIARES [cite: 191]
    public AntecedentesFamiliares Antecedentes { get; set; } = new();

    [cite_start]// VI - AMBIENTE FAMILIAR E SOCIAL [cite: 195]
    public AmbienteSocial Ambiente { get; set; } = new();
}

public class IdentificacaoAdolescente
{
    public string Nome { get; set; } = string.Empty; [cite: 157]
    public DateTime? DataNascimento { get; set; } [cite: 158]
    public int Idade { get; set; } [cite: 159]
    public string Sexo { get; set; } = string.Empty; [cite: 160]
    public string Escolaridade { get; set; } = string.Empty; [cite: 161]
    public string Escola { get; set; } = string.Empty; [cite: 162]

    [cite_start]// Filiação [cite: 163, 167]
    public DadosResponsavel Pai { get; set; } = new();
    public DadosResponsavel Mae { get; set; } = new();
    public string CondicaoConjugalPais { get; set; } = string.Empty; [cite: 171]
}

public class DadosResponsavel
{
    public int Idade { get; set; } [cite: 164, 168]
    public string Instrucao { get; set; } = string.Empty; [cite: 165, 169]
    public string Profissao { get; set; } = string.Empty; [cite: 166, 170]
}

public class MotivoConsulta
{
    public string Principal { get; set; } = string.Empty; [cite: 173]
    public string TempoQueixa { get; set; } = string.Empty; [cite: 174] // Refere-se ao "Desde quando?"
    public string AtitudeMae { get; set; } = string.Empty; [cite: 176]
    public string AtitudePai { get; set; } = string.Empty; [cite: 177]
    public string AtitudeOutrosFamiliares { get; set; } = string.Empty; [cite: 180, 181]
}

public class DesenvolvimentoAdolescente
{
    public string Linguagem { get; set; } = string.Empty; [cite: 185]
    public string DesenvolvimentoPsicomotor { get; set; } = string.Empty; [cite: 186]
    public string Sono { get; set; } = string.Empty; [cite: 187]
    public string Alimentacao { get; set; } = string.Empty; [cite: 188]
    public string Tiques { get; set; } = string.Empty; [cite: 189]
    public string DificuldadeEscolar { get; set; } = string.Empty; [cite: 190]
}

public class AntecedentesFamiliares
{
    public bool AlguemNervosoNaFamilia { get; set; } [cite: 192]
    public string DescricaoNervoso { get; set; } = string.Empty; [cite: 193]
    public bool AlguemComProblemaMental { get; set; } [cite: 194]
    public string Vicios { get; set; } = string.Empty; [cite: 194]
}

public class AmbienteSocial
{
    public string LocalEstudo { get; set; } = string.Empty; [cite: 196]
    public string TiposDiversao { get; set; } = string.Empty; [cite: 199]
    public bool FamiliaFazVisitas { get; set; } [cite: 201]
    public bool FamiliaRecebeVisitas { get; set; } [cite: 202]
    public string Companheiros { get; set; } = string.Empty; [cite: 203]
    public string QuemEscolheCompanheiros { get; set; } = string.Empty; [cite: 204]
    public string Religiao { get; set; } = string.Empty; [cite: 205]
}
 
 */