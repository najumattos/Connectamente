using Connectamente.API.DTOs.PsicologoDto;
using FluentResults;

namespace Connectamente.API.Services.Interfaces;

public interface IPsicologoService
{
       /// <summary>
    /// Busca a ficha detalhada de um psicologo específico através do seu identificador único.
    /// </summary>
    /// <param name="id">O identificador numérico único do psicologo.</param>
    /// <returns>
    /// Um objeto <see cref="Result"/> encapsulando o <see cref="psicologoDetalhesDto"/> se encontrado,
    /// ou uma falha de validação/not found.
    /// </returns>
    Task<Result<PsicologoDetalhesDto>> BuscarPsicologoPorIdAsync(string id);
    /// <summary>
    /// Obtém a listagem completa de todos os psicologos cadastrados no sistema.
    /// </summary>
    /// <returns>
    /// Um objeto <see cref="Result"/> contendo a coleção de <see cref="PsicologoListaDto"/> em caso de sucesso,
    /// ou mensagens de erro detalhadas em caso de falha.
    /// </returns>
    Task<Result<IEnumerable<PsicologoListaDto>>> BuscarTodosPsicologosAsync();

    public Task<Result<IEnumerable<PsicologoListaDto>>> BuscarPsicologosDisponiveisAsync();    
}