using Connectamente.API.Domain;
using Connectamente.API.Models.ViewModel;

namespace Connectamente.API.Data.Repositories.PsicologoRepository
{
    public interface IPsicologoRepository
    {
        public Task<Result<IEnumerable<UsuarioListaDto>>> BuscarTodosPsicologos();
        public Task<Result<PsicologoDto>> BuscarPsicologoPorId(string idPsicologo);
    }
}
