using Connectamente.API.DTOs.ProntuarioDto;
using FluentResults;

namespace Connectamente.API.Services.Interfaces;

/// <summary>
/// Define os contratos de serviços de negócio para a gestão de prontuarios.
/// </summary>
public interface IProntuarioService
{
  /// <summary>
    /// Obtém a listagem completa de todos os prontuarios cadastrados no sistema.
    /// </summary>
    /// <returns>
    /// Um objeto <see cref="Result"/> contendo a coleção de <see cref="ProntuarioListaDto"/> em caso de sucesso,
    /// ou mensagens de erro detalhadas em caso de falha.
    /// </returns>
    Task<Result<IEnumerable<ProntuarioListaDto>>> BuscarTodosProntuariosAsync();

    /// <summary>
    /// Obtém a listagem completa de todos os prontuarios de um psicologo.
    /// </summary>
    /// <returns>
    /// Um objeto <see cref="Result"/> contendo a coleção de <see cref="ProntuarioListaDto"/> em caso de sucesso,
    /// ou mensagens de erro detalhadas em caso de falha.
    /// </returns>
    Task<Result<IEnumerable<ProntuarioListaDto>>> BuscarTodosProntuariosDeUmPsicologoAsync(string idPsicologo);

    /// <summary>
    /// Busca a ficha detalhada de um prontuario específico através do seu identificador único.
    /// </summary>
    /// <param name="id">O identificador numérico único do prontuario.</param>
    /// <returns>
    /// Um objeto <see cref="Result"/> encapsulando o <see cref="ProntuarioDetalhesDto"/> se encontrado,
    /// ou uma falha de validação/not found.
    /// </returns>
    Task<Result<ProntuarioDetalhesDto>> BuscarProntuarioPorIdAsync(int id);

    /// <summary>
    /// Realiza o arquivamento (desativação lógica) de um prontuario no sistema.
    /// </summary>
    /// <param name="id">O identificador numérico único do prontuario a ser arquivado.</param>
    /// <returns>
    /// Um objeto <see cref="Result"/> sem tipo de retorno que indica estritamente se a operação 
    /// foi bem-sucedida ou se falhou por regras de negócio.
    /// </returns>
    Task<Result> ArquivarProntuarioAsync(int id);
}