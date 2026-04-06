using Connectamente.API.Domain;
using Connectamente.API.Models.ViewModel;
using System.Collections.Generic;

namespace Connectamente.API.Data.Repositories.PacienteRepository
{
    public class PacienteRepository : IPacienteRepository
    {

        public Task<Result<PacienteDto>> BuscarPacientePorId(string idPaciente)
        {
            //PacienteModel is null
            if (idPaciente is null)
            {
                //no futuro esse será um metodo async, dai nao precisará desseTask.FromResult() 
                return Task.FromResult(Result<PacienteDto>.Failure("Paciente não encontrado"));
            }
            // o caminho ta certo ate aqui, só falta implementar mesmo
            throw new NotImplementedException();  
        }

        public Task<Result<IEnumerable<UsuarioListaDto>>> BuscarPacientesPorPsicologo(string idPsicologo)
        {

            //filtrar pacientes por Idpsicologo
            // o caminho ta certo ate aqui, só falta implementar mesmo
            throw new NotImplementedException();
        }

        public Task<Result<IEnumerable<UsuarioListaDto>>> BuscarTodosPacientes()
        {
            //buscar todos pacientes sem filtros
            // o caminho ta certo ate aqui, só falta implementar mesmo
            throw new NotImplementedException();
        }
    }
}
