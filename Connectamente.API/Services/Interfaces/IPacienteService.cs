using Connectamente.API.DTOs.PacienteDto;
using FluentResults;

namespace Connectamente.API.Services.Interfaces;

/// <summary>
/// Define os contratos de serviços de negócio para a gestão de pacientes.
/// </summary>
public interface IPacienteService
{
    /// <summary>
    /// Obtém a listagem completa de todos os pacientes cadastrados no sistema.
    /// </summary>
    /// <returns>
    /// Um objeto <see cref="Result"/> contendo a coleção de <see cref="PacienteListaDto"/> em caso de sucesso,
    /// ou mensagens de erro detalhadas em caso de falha.
    /// </returns>
    Task<Result<IEnumerable<PacienteListaDto>>> BuscarTodosPacientesAsync();

    /// <summary>
    /// Busca a ficha detalhada de um paciente específico através do seu identificador único.
    /// </summary>
    /// <param name="id">O identificador numérico único do paciente.</param>
    /// <returns>
    /// Um objeto <see cref="Result"/> encapsulando o <see cref="PacienteDetalhesDto"/> se encontrado,
    /// ou uma falha de validação/not found.
    /// </returns>
    Task<Result<PacienteDetalhesDto>> BuscarPacientePorIdAsync(int id);

    /// <summary>
    /// Realiza o arquivamento (desativação lógica) de um paciente no sistema.
    /// </summary>
    /// <param name="id">O identificador numérico único do paciente a ser arquivado.</param>
    /// <returns>
    /// Um objeto <see cref="Result"/> sem tipo de retorno que indica estritamente se a operação 
    /// foi bem-sucedida ou se falhou por regras de negócio.
    /// </returns>
    Task<Result> ArquivarPacienteAsync(int id);
}