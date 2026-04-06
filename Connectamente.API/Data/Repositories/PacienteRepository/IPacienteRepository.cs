using Connectamente.API.Domain;
using Connectamente.API.Enums;
using Connectamente.API.Models.ViewModel;

namespace Connectamente.API.Data.Repositories.PacienteRepository;

public interface IPacienteRepository
{
    public Task<Result<IEnumerable<UsuarioListaDto>>> BuscarTodosPacientes();
    public Task<Result<IEnumerable<UsuarioListaDto>>> BuscarPacientesPorPerfil(TipoPerfilEnum tipoPerfil);
    public Task<Result<IEnumerable<UsuarioListaDto>>> BuscarPacientesPorPsicologo(string idPsicologo);
    public Task<Result<PacienteDto>> BuscarPacientePorId(string idPaciente);
}