
using Connectamente.API.Models;

/// <summary>
/// Interface de persistência para as informações cadastrais de familiares de pacientes.
/// </summary>
namespace Connectamente.API.Repositories.Interfaces;

public interface IFamiliarRepository
{

	/// <summary>
	/// Lista todos os familiares vinculados a um paciente específico.
	/// </summary>
	/// <param name="prontuarioId">Identificador do paciente usado no filtro.</param>
	/// <returns>
	/// Uma tarefa assíncrona que retorna a lista de familiares associados ao paciente informado.
	/// </returns>
	Task<IEnumerable<FamiliarModel>> BuscarPorProntuarioIdAsync(int prontuarioId);

/// <summary>
    /// Recupera todas as informações de familiares registradas no banco de dados.
    /// </summary>
    /// <returns>Uma lista completa de <see cref="FamiliarModel"/>.</returns>
    Task<IEnumerable<FamiliarModel>> BuscarTodosAsync();

	/// <summary>
    /// Retorna os detalhes de um familiar, incluindo o grafo de pacientes associados.
    /// </summary>
    /// <param name="id">O ID das informações familiares.</param>
    /// <returns>A instância encontrada ou <see langword="null"/>.</returns>
    Task<FamiliarModel?> BuscarDetalhesAsync(int id);

    /// <summary>
    /// Modifica os dados cadastrais do familiar na base de dados.
    /// </summary>
    /// <param name="Familiar">A entidade modificada.</param>
    Task EditarAsync(FamiliarModel Familiar);

    /// <summary>
    /// Adiciona um novo registro de informações familiares.
    /// </summary>
    /// <param name="Familiar">A nova entidade.</param>
    /// <returns>A entidade persistida com ID populado.</returns>
    Task<FamiliarModel> AdicionarAsync(FamiliarModel Familiar);

    /// <summary>
    /// Remove fisicamente o familiar do banco de dados.
    /// </summary>
    /// <param name="id">O ID do familiar.</param>
    /// <returns>Booleano indicando se a linha foi removida.</returns>
    Task<bool> ExcluirAsync(int id);
}

