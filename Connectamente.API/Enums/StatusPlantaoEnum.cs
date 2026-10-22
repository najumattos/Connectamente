namespace Connectamente.API.Models;

public enum StatusPlantaoEnum
{

    EncerradoPeloPaciente = 1,  //paciente nao quis dar continuidade, nao quis aguardar uma vaga
    EmAndamento = 2,       
    EncerradoPelaClinica = 3,
    AguardandoAtendimento = 4, //aguardando abrir uma vaga na clinica depois que o plantao acabou
    PacienteEfetivado = 5
}