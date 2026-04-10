using Connectamente.API.Domain;
using Connectamente.API.Models.ViewModel;

namespace Connectamente.API.Data.Repositories.PsicologoRepository;

public class PsicologoRepository : IPsicologoRepository
{
    /// <summary>
    /// Retorna Psicologo
    /// </summary> 
    public Task<Result<PsicologoDto>> BuscarPsicologoPorId(string idPsicologo)
    {           
        throw new NotImplementedException();
    }

    /// <summary>
    /// Retorna Todos Psicologos
    /// </summary> 
    public Task<Result<IEnumerable<UsuarioListaDto>>> BuscarTodosPsicologos()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Desativa Psicologo
    /// </summary> 
    public Task<Result<bool>> DesativarPsicologo(string idPsicologo)
    {
        throw new NotImplementedException();
    }
}

/* Dessa maneira se o perfil nao for coordendor ou o idPsicologo nao for igual ao id da requisição
* os dados do psicologo nao sao exibidos. 
* Outros alunos nao podem acesssar os dados de seus colegas psicologos, apenas os seus proprios dados.
*
*/