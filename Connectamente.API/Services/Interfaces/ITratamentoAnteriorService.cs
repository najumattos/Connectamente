using Connectamente.API.DTOs.TratamentoAnteriorDto;
using FluentResults;

namespace Connectamente.API.Services.Interfaces;

public interface ITratamentoAnteriorService
{
    /// <summary>
    /// Exibe detalhes de um tratamento anterior de um paciente através do seu identificador único.
    /// </summary>
    /// <param name="id">O identificador numérico único do tratamento anterior.</param>
    /// <returns>
    /// Um objeto <see cref="Result"/> encapsulando o <see cref="TratamentoAnteriorDetalhesDto"/> se encontrado,
    /// ou uma falha de validação/not found.
    /// </returns>
    Task<Result<TratamentoAnteriorDetalhesDto>> BuscarTratamentoAnteriorPorIdAsync(int id);

    /// <summary>
    /// Realiza a inclusão de um novo registro de tratamento anterior no sistema.
    /// </summary>
    /// <param name="dto">O DTO contendo os dados necessários para a criação do tratamento anterior.</param>
    /// <returns>
    /// Um objeto <see cref="Result"/> indicando se a criação foi bem-sucedida ou se falhou
    /// devido a inconsistências nas regras de negócio.
    /// </returns>
    Task<Result> AdicionarTratamentoAnteriorAsync(TratamentoAnteriorAdicionarDto dto);

    /// <summary>
    /// Atualiza as informações clínicas de um tratamento anterior existente.
    /// </summary>
    /// <param name="dto">O DTO com os dados atualizados vindos do formulário de edição.</param>
    /// <returns>
    /// Um objeto <see cref="Result"/> sem tipo de retorno que indica se a atualização 
    /// foi persistida com sucesso ou se violou regras de validação.
    /// </returns>
    Task<Result> EditarTratamentoAnteriorAsync(TratamentoAnteriorDetalhesDto dto);

    /// <summary>
    /// Realiza a exclusão de um tratamento anterior do banco de dados.
    /// </summary>
    /// <param name="id">O identificador numérico único do tratamento a ser excluído.</param>
    /// <returns>
    /// Um objeto <see cref="Result"/> sem tipo de retorno que indica estritamente se a operação 
    /// foi bem-sucedida ou se falhou por regras de negócio ou infraestrutura.
    /// </returns>
    Task<Result> DeletarTratamentoAnteriorAsync(int id);
}