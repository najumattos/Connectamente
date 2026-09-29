using Connectamente.API.Models;

namespace Connectamente.API.Repositories.Interfaces;

/// <summary>
/// Interface de persistência e consulta para a gestão de usuários da aplicação (<see cref="ApplicationUserModel"/>).
/// </summary>
public interface IApplicationUserRepository
{
	/// <summary>
    /// Recupera todos os usuários registrados no sistema sem a aplicação de paginação ou filtros.
    /// </summary>
    /// <remarks>
    /// <b>Aviso de performance:</b> Por retornar todos os registros de uma só vez, certifique-se de utilizar 
    /// projeções ou otimizações de leitura (como AsNoTracking) na implementação deste método.
    /// </remarks>
    /// <returns>Uma coleção contendo todas as instâncias de <see cref="ApplicationUserModel"/> presentes na base.</returns>
    Task<IEnumerable<ApplicationUserModel>> BuscarTodosAsync();

    /// <summary>
    /// Obtém os dados detalhados de um usuário específico utilizando o seu identificador único de formato textual.
    /// </summary>
    /// <param name="id">O identificador alfanumérico único (string/GUID) gerado pelo subsistema do ASP.NET Identity.</param>
    /// <returns>A instância populada de <see cref="ApplicationUserModel"/> acompanhada de suas coleções mapeadas, ou <see langword="null"/> caso não seja localizada.</returns>
    Task<ApplicationUserModel?> BuscarDetalhesAsync(string id);

    /// <summary>
    /// Atualiza as propriedades cadastrais e estados modificados de um usuário já existente.
    /// </summary>
    /// <param name="usuario">A instância do usuário contendo as alterações a serem consolidadas no banco de dados.</param>
    Task EditarAsync(ApplicationUserModel usuario);

    /// <summary>
    /// Realiza a inclusão e persistência de um novo usuário no banco de dados.
    /// </summary>
    /// <param name="usuario">A nova instância de usuário a ser criada.</param>
    /// <returns>O objeto correspondente ao usuário persistido.</returns>
    Task<ApplicationUserModel> AdicionarAsync(ApplicationUserModel usuario);

    /// <summary>
    /// Executa o arquivamento ou desativação lógica do usuário, modificando sua flag de atividade para impedir acessos operacionais sem excluir o registro físico.
    /// </summary>
    /// <param name="id">O identificador alfanumérico único (string) do usuário a ser desativado.</param>
    /// <returns><see langword="true"/> se a alteração de estado foi efetuada e gravada com sucesso; caso contrário, <see langword="false"/>.</returns>
    Task<bool> ArquivarAsync(string id);

    /// <summary>
    /// Remove permanentemente o registro do usuário e todos os dados estritos associados da base de dados física.
    /// </summary>
    /// <param name="id">O identificador alfanumérico único (string) do usuário a ser removido.</param>
    /// <returns><see langword="true"/> se o comando de exclusão foi concluído com sucesso; caso contrário, <see langword="false"/>.</returns>
    Task<bool> ExcluirAsync(string id);

	/// <summary>
	/// Busca um usuário pelo CPF.
	/// </summary>
	/// <param name="cpf">CPF do usuário a ser localizado.</param>
	/// <returns>
	/// Uma tarefa assíncrona que retorna o usuário encontrado ou <c>null</c> quando não existir.
	/// </returns>
	Task<ApplicationUserModel> BuscarPorCpfAsync(string cpf);

    IQueryable<ApplicationUserModel> ObterQueryable();
    
    	
}