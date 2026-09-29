using Connectamente.API.Models;

namespace Connectamente.API.Repositories.Interfaces;

/// <summary>
/// Interface para manipulação de históricos de tratamentos anteriores do paciente vinculados ao prontuário.
/// </summary>
public interface ITratamentoAnteriorRepository
{
    /// <summary>
    /// Coleta todos os registros de tratamentos anteriores inseridos no sistema.
    /// </summary>
    Task<IEnumerable<TratamentoAnteriorModel>> BuscarTodosAsync();


    /// <summary>
    /// Retorna os dados completos e o prontuário de um registro de tratamento anterior específico.
    /// </summary>
    /// <param name="id">O ID do registro de tratamento anterior.</param>
    Task<TratamentoAnteriorModel?> BuscarDetalhesAsync(int id);

    /// <summary>
    /// Modifica um registro de tratamento anterior existente.
    /// </summary>
    /// <param name="tratamentoAnterior">A instância com as novas informações.</param>
    Task EditarAsync(TratamentoAnteriorModel tratamentoAnterior);

    /// <summary>
    /// Cadastra um novo registro de tratamento anterior no prontuário do paciente.
    /// </summary>
    /// <param name="tratamentoAnterior">O histórico a ser inserido.</param>
    Task<TratamentoAnteriorModel> AdicionarAsync(TratamentoAnteriorModel tratamentoAnterior);


    /// <summary>
    /// Exclui definitivamente o histórico do banco de dados.
    /// </summary>
    /// <param name="id">O ID do tratamento anterior.</param>
    Task<bool> ExcluirAsync(int id);
}