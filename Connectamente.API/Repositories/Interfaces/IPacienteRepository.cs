using Connectamente.API.Models;

namespace Connectamente.API.Repositories.Interfaces;

/// <summary>
/// Contrato de persistência e consulta para a entidade <see cref="PacienteModel"/>.
/// </summary>
public interface IPacienteRepository
{
    /// <summary>
    /// Obtém um paciente por seu identificador único.
    /// </summary>
    /// <param name="id">Identificador único do paciente.</param>
    /// <returns>A entidade do paciente se encontrado; caso contrário, <see langword="null"/>.</returns>
    Task<PacienteModel?> ObterPorIdAsync(int id);

    /// <summary>
    /// Obtém um paciente detalhado, incluindo seu Prontuário e informações de Familiares associados.
    /// </summary>
    /// <param name="id">Identificador único do paciente.</param>
    /// <returns>A entidade completa do paciente se encontrado; caso contrário, <see langword="null"/>.</returns>
    Task<PacienteModel?> ObterCompletoPorIdAsync(int id);

    /// <summary>
    /// Obtém uma lista paginada de pacientes filtrados pelo nome.
    /// </summary>
    /// <param name="nome">Trecho do nome para filtro (opcional).</param>
    /// <param name="skip">Quantidade de registros a serem pulados.</param>
    /// <param name="take">Quantidade de registros a serem retornados.</param>
    /// <returns>Uma coleção de pacientes que atendem aos critérios.</returns>
    Task<IEnumerable<PacienteModel>> ObterPaginadoAsync(string? nome, int skip, int take);

    /// <summary>
    /// Verifica se já existe um paciente cadastrado com o CPF informado.
    /// </summary>
    /// <param name="cpf">O CPF a ser validado.</param>
    /// <returns><see langword="true"/> se o CPF já estiver em uso; caso contrário, <see langword="false"/>.</returns>
    Task<bool> ExisteCpfAsync(string cpf);

    /// <summary>
    /// Adiciona um novo paciente ao contexto de persistência.
    /// </summary>
    /// <param name="paciente">A entidade do paciente a ser inserida.</param>
    Task AdicionarAsync(PacienteModel paciente);

    /// <summary>
    /// Atualiza os dados de um paciente existente.
    /// </summary>
    /// <param name="paciente">A entidade do paciente com os dados modificados.</param>
    void Atualizar(PacienteModel paciente);

    /// <summary>
    /// Realiza Deleção lógica do paciente alterando a propriedade 'Ativo' herdada de <see cref="EntityBase"/>.
    /// </summary>  
    /// <param name="paciente">A entidade do paciente a ser removida.</param>
    void Remover(PacienteModel paciente);
}