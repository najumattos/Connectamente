using Connectamente.API.Domain;
using Connectamente.API.Models.ViewModel;

namespace Connectamente.API.Data.Repositories.PsicologoRepository
{
    public class PsicologoRepository : IPsicologoRepository
    {
        public Task<Result<PsicologoDto>> BuscarPsicologoPorId(string idPsicologo)
        {
            //PsicologoModel is null
            if (idPsicologo is null)
            {
                //no futuro esse será um metodo async, dai nao precisará desseTask.FromResult() 
                return Task.FromResult(Result<PsicologoDto>.Failure("Psicologo não encontrado"));
            }
            // VERIFICAR caminho ate aqui para implementar
            throw new NotImplementedException();
        }

        public Task<Result<IEnumerable<UsuarioListaDto>>> BuscarTodosPsicologos()
        {
            //buscar todos psicologos sem filtros
            // VERIFICAR caminho ate aqui para implementar
            throw new NotImplementedException();
        }
    }
}

/* Dessa maneira se o perfil nao for coordendor ou o idPsicologo nao for igual ao id da requisição
 * os dados do psicologo nao sao exibidos. 
 * Outros alunos nao podem acesssar os dados de seus colegas psicologos, apenas os seus proprios dados.
 *
 */