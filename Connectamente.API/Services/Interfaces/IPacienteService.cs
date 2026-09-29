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
    Task<Result<IEnumerable<PacienteListaDto>>> BuscarPacientesPorIdPsicologoAsync(string idPsicologo);


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
    /// Executa as validações de negócio e insere o novo paciente  no sistema.
    /// </summary>
    /// <param name="dto">O DTO contendo os dados iniciais do paciente  a ser cadastrado.</param>
    /// <returns>Um objeto Result contendo </returns>
    public Task<Result<int>> AdicionarPacienteAsync(PacienteAdicionarDto dto);

    /// <summary>
    /// Realiza o arquivamento (desativação lógica) de um paciente no sistema.
    /// </summary>
    /// <param name="id">O identificador numérico único do paciente a ser arquivado.</param>
    /// <returns>
    /// Um objeto <see cref="Result"/> sem tipo de retorno que indica estritamente se a operação 
    /// foi bem-sucedida ou se falhou por regras de negócio.
    /// </returns>
    Task<Result> ArquivarPacienteAsync(int id);

        /// <summary>
    /// Atualiza as informações clínicas de um paciente existente.
    /// </summary>
    /// <param name="dto">O DTO com os dados atualizados vindos do formulário de edição.</param>
    /// <returns>
    /// Um objeto <see cref="Result"/> sem tipo de retorno que indica se a atualização 
    /// foi persistida com sucesso ou se violou regras de validação.
    /// </returns>
    Task<Result> EditarPacienteAsync(PacienteDetalhesDto dto);

}