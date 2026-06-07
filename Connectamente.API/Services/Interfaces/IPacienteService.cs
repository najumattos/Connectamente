using Connectamente.API.Domain;
using Connectamente.API.DTOs;
 namespace Connectamente.API.Services.Interfaces;

public interface IPacienteService
{
    public Task<Result<IEnumerable<UsuarioListaDto>>> BuscarTodosPacientes();
    public Task<Result<PacienteDto>> BuscarPacientePorId(string idPaciente);
    public Task<Result<bool>> ArquivarPaciente(string idPaciente);
}


/*
 *  public Task<Result<PacienteDto>> BuscarPacientePorId(string idPaciente) ?
 *
 * Se o método for apenas BuscarPacientePorId(string idPaciente), qualquer pessoa
 * que descobrir o ID de um paciente (por exemplo, testando números na URL da API)
 * conseguirá ver os dados dele.
 * Isso é uma falha de segurança grave chamada IDOR (Insecure Direct Object Reference).
 * 
 * O Repository busca o dado puramente pelo ID (ele é o executor).
 * O Service valida se o usuário logado tem permissão de ver aquele ID específico
 * Se um Aluno tentar buscar o ID de um paciente que pertence a outro Aluno, o seu Service deve barrar, mesmo que o ID do paciente exista no banco.
 */