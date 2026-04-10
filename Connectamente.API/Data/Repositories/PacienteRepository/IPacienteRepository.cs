using Connectamente.API.Domain;
using Connectamente.API.Enums;
using Connectamente.API.Models.ViewModel;

namespace Connectamente.API.Data.Repositories.PacienteRepository;

public interface IPacienteRepository
{
    public Task<Result<IEnumerable<UsuarioListaDto>>> BuscarTodosPacientes();
    public Task<Result<IEnumerable<UsuarioListaDto>>> FiltrarPacientesPorPsicologo(string idPsicologo);
    public Task<Result<PacienteDto>> BuscarPacientePorId(string idPaciente);
    public Task<Result<bool>> ArquivarPaciente(string idPaciente);
}