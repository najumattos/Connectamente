namespace Connectamente.API.Models;

public class AtendimentoModel 
{
    //atendimento pode ter como PK a FK de Agendamento?
       public int AgendamentoId { get; set; }
    public AgendamentoModel Agendamento { get; set; } = null!;     

    public int ProntuarioId { get; set; }
    public ProntuarioModel Prontuario { get; set; } = null!;
}