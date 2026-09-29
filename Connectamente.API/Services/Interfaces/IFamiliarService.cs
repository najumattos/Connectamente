using Connectamente.API.DTOs.FamiliarDto;
using FluentResults;

namespace Connectamente.API.Services.Interfaces;

public interface IFamiliarService
{
    /// <summary>
    /// Exibe detalhes de um familiar de um paciente através do seu identificador único.
    /// </summary>
    /// <param name="id">O identificador numérico único do familiar.</param>
    /// <returns>
    /// Um objeto <see cref="Result"/> encapsulando o <see cref="FamiliarDetalhesDto"/> se encontrado,
    /// ou uma falha de validação/not found.
    /// </returns>
    Task<Result<FamiliarDetalhesDto>> BuscarFamiliarPorIdAsync(int id);

    /// <summary>
    /// Realiza a inclusão de um novo registro de familiar no sistema.
    /// </summary>
    /// <param name="dto">O DTO contendo os dados necessários para a criação do familiar</param>
    /// <returns>
    /// Um objeto <see cref="Result"/> indicando se a criação foi bem-sucedida ou se falhou
    /// devido a inconsistências nas regras de negócio.
    /// </returns>
    Task<Result> AdicionarFamiliarAsync(FamiliarAdicionarDto dto);

    /// <summary>
    /// Atualiza as informações clínicas de um familiar existente.
    /// </summary>
    /// <param name="dto">O DTO com os dados atualizados vindos do formulário de edição.</param>
    /// <returns>
    /// Um objeto <see cref="Result"/> sem tipo de retorno que indica se a atualização 
    /// foi persistida com sucesso ou se violou regras de validação.
    /// </returns>
    Task<Result> EditarFamiliarAsync(FamiliarDetalhesDto dto);

    /// <summary>
    /// Realiza a exclusão de um familiar do banco de dados.
    /// </summary>
    /// <param name="id">O identificador numérico único do familiar a ser excluído.</param>
    /// <returns>
    /// Um objeto <see cref="Result"/> sem tipo de retorno que indica estritamente se a operação 
    /// foi bem-sucedida ou se falhou por regras de negócio ou infraestrutura.
    /// </returns>
    Task<Result> DeletarFamiliarAsync(int id);
}