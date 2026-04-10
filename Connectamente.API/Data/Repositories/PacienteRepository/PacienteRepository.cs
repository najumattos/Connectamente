using Connectamente.API.Domain;
using Connectamente.API.Enums;
using Connectamente.API.Models.ViewModel;
using System.Collections.Generic;

namespace Connectamente.API.Data.Repositories.PacienteRepository;

public class PacienteRepository : IPacienteRepository
{
    /// <summary>
    /// Arquivar Paciente
    /// </summary>          
    public Task<Result<bool>> ArquivarPaciente(string id)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Retorna Paciente Por ID
    /// </summary>
    public Task<Result<PacienteDto>> BuscarPacientePorId(string id)
    {          
        throw new NotImplementedException();  
    }

    /// <summary>
    /// Retorna Pacientes por PsicologoResponsavelId
    /// </summary>
    public Task<Result<IEnumerable<UsuarioListaDto>>> FiltrarPacientesPorPsicologo(string idPsicologo)
    {
        throw new NotImplementedException();
    }
  
    /// <summary>
    /// Retorna Todos Pacientes
    /// </summary>
    public Task<Result<IEnumerable<UsuarioListaDto>>> BuscarTodosPacientes()
    {
        throw new NotImplementedException();
    }
}
