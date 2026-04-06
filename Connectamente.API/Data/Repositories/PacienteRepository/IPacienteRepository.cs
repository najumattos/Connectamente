using Connectamente.API.Domain;
using Connectamente.API.Models.ViewModel;

namespace Connectamente.API.Data.Repositories.PacienteRepository;

public interface IPacienteRepository
{
    public Task<Result<IEnumerable<UsuarioListaDto>>> BuscarTodosPacientes();
    public Task<Result<IEnumerable<UsuarioListaDto>>> BuscarPacientesPorPsicologo(string idPsicologo);
    public Task<Result<PacienteDto>> BuscarPacientePorId(string idPaciente);
}

/* Verificar se a requisição ta chegando ate aqui
 * Verificar authAcessoDto
 * Verficar se Result Pattern ta funcionando
 * 
 * No front preencher o AuthAcessoDto antes de fazer a requisição.
 * Verificar se o coordenador consegue buscar todos os pacientes
 * 
 */